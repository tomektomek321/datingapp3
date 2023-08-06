using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Domain.Entities;
public class Hobby
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HobbiesCategoryId { get; set; }
    public HobbiesCategory HobbiesCategory { get; set; }
}
