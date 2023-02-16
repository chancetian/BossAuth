using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.User
{
    public class GetRoutersDto
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Path { set; get; }
        public bool Hidden { set; get; } = false;
        public string? Redirect { set; get; }
        public string Component { set; get; }
        public bool AlwaysShow { set; get; }
        public MetaModel Meta { set; get; }
        public List<GetRoutersDto> Children { set; get; }
    }
    public class MetaModel
    {
        public string Title { set; get; }
        public string Icon { set; get; }
        public bool NoCache { set; get; }
        public string Link{ set; get; }
    }

}
