using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctByApp.Models;
public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Released { get; set; }
    public int Rating { get; set; }
    public override string ToString() => Name;

}

public enum Rating
{
    Excellent,
    Good,
    Fair,
    Poor
}
