﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using System.ComponentModel;

namespace ISetSamples.Models;

public partial class Customers : INotifyPropertyChanged, IEquatable<Customers>
{
    private int _id;
    private string _company;
    private string _contactType;
    private string _contactName;
    private string _country;
    private DateOnly _joinDate;

    public int Id
    {
        get => _id;
        set
        {
            if (value == _id) return;
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public string Company
    {
        get => _company;
        set
        {
            if (value == _company) return;
            _company = value;
            OnPropertyChanged(nameof(Company));
        }
    }

    public string ContactType
    {
        get => _contactType;
        set
        {
            if (value == _contactType) return;
            _contactType = value;
            OnPropertyChanged(nameof(ContactType));
        }
    }

    public string ContactName
    {
        get => _contactName;
        set
        {
            if (value == _contactName) return;
            _contactName = value;
            OnPropertyChanged(nameof(ContactName));
        }
    }

    public string Country
    {
        get => _country;
        set
        {
            if (value == _country) return;
            _country = value;
            OnPropertyChanged(nameof(Country));
        }
    }

    public DateOnly JoinDate
    {
        get => _joinDate;
        set
        {
            if (value.Equals(_joinDate)) return;
            _joinDate = value;
            OnPropertyChanged(nameof(JoinDate));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool Equals(Customers other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Company == other.Company && Country == other.Country && JoinDate.Equals(other.JoinDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Customers)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (Company != null ? Company.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ JoinDate.GetHashCode();
            return hashCode;
        }
    }
}