using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using GetStartedWinForms.Classes;
// ReSharper disable PossibleNullReferenceException

namespace GetStartedWinForms
{
    public partial class MainForm : Form
    {
        private ProductsContext? _dbContext;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _dbContext = new ProductsContext();

            // Uncomment the line below to start fresh with a new database.
            // this.dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.Categories.Load();

            categoryBindingSource.DataSource = _dbContext.Categories.Local.ToBindingList();

            dataGridViewCategories.ExpandColumns();
            dataGridViewProducts.ExpandColumns();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _dbContext?.Dispose();
            _dbContext = null;
        }

        private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (_dbContext != null)
            {
                var category = (Category)dataGridViewCategories.CurrentRow.DataBoundItem;

                if (category != null)
                {
                    _dbContext.Entry(category).Collection(cat => cat.Products).Load();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _dbContext!.SaveChanges();
            dataGridViewCategories.Refresh();
            dataGridViewProducts.Refresh();
        }
    }
}
