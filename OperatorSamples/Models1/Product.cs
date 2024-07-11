#pragma warning disable CS8618
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OperatorSamples.Models1;

/// <summary>
/// INotifyPropertyChanged is needed for Form2, not Form1
/// </summary>
public class Product : INotifyPropertyChanged
{
    private int _productId;
    private string _productName;
    private decimal _unitPrice;
    private short _unitsInStock;

    public int ProductId
    {
        get => _productId;
        set
        {
            if (value == _productId) return;
            _productId = value;
            OnPropertyChanged();
        }
    }

    public string ProductName
    {
        get => _productName;
        set
        {
            if (value == _productName) return;
            _productName = value;
            OnPropertyChanged();
        }
    }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            if (value == _unitPrice) return;
            _unitPrice = value;
            OnPropertyChanged();
        }
    }

    public short UnitsInStock
    {
        get => _unitsInStock;
        set
        {
            if (value == _unitsInStock) return;
            _unitsInStock = value;
            OnPropertyChanged();
        }
    }

    public Product(int id)
    {
        ProductId = id;
    }

    public Product()
    {
        
    }

    public override string ToString() => ProductName;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}