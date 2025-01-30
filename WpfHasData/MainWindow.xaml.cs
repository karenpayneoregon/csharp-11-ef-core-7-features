using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using WpfHasData.Classes;

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

namespace WpfHasData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductContext _context = new();

        private CollectionViewSource categoryViewSource;

        public MainWindow()
        {
            InitializeComponent();
            
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            MockedData.CreateIfNeeded(_context);
        
            _context.Categories.Load();

            categoryViewSource.Source = _context.Categories.Local.ToObservableCollection();
            SortDataGrid(categoryDataGrid,1);

            var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
            dpd?.AddValueChanged(productsDataGrid, CalledWhenPropertyIsChanged);

            SortDataGrid(productsDataGrid, 2);
        }

        /// <summary>
        /// Handles the event triggered when the <see cref="ItemsControl.ItemsSourceProperty"/> of the 
        /// <see cref="DataGrid"/> is changed.
        /// </summary>
        /// <param name="sender">The source of the event, typically the <see cref="DataGrid"/>.</param>
        /// <param name="e">The event data associated with the property change.</param>
        private void CalledWhenPropertyIsChanged(object sender, EventArgs e)
        {
            SortDataGrid(productsDataGrid, 2);
            productsDataGrid.SelectedIndex = 0;
        }

        // not used in this example
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }

        /// <summary>
        /// Sorts the specified <see cref="DataGrid"/> by a given column and direction.
        /// </summary>
        /// <param name="dataGrid">The <see cref="DataGrid"/> to be sorted.</param>
        /// <param name="columnIndex">
        /// The index of the column to sort. Defaults to 0 if not specified.
        /// </param>
        /// <param name="sortDirection">
        /// The direction of the sort, either ascending or descending. Defaults to <see cref="ListSortDirection.Ascending"/>.
        /// </param>
        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];

            dataGrid.Items.SortDescriptions.Clear();

            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            dataGrid.Items.Refresh();
        }
    }
}
