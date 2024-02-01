using ContainerToolDBDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerToolDB;

public class Article
{
    public int Id { get; set; }
    public int ArticleNumber { get; set; } 
    public bool IsDirectLine { get; set; }
    public bool IsFastLine { get; set; } 
    public int Pallets { get; set; }
    public int CsinquiryId { get; set; }
    public virtual Csinquiry Csinquiry { get; set; } = null!;
}
