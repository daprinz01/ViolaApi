using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViolaApi.DLL
{
    public class SocialNetworks
    {
        public SocialNetworks()
        {
            ApiAssets = new ObservableCollection<ApiAssets>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Key { get; set; }
        public ViolaUser ViolaUser { get; set; }
        public ObservableCollection<ApiAssets> ApiAssets { get; set; }
    }
}
