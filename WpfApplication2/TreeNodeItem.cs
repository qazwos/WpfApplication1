using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
   public class TreeNodeItem
     {
         private string _icon = "Icon";
         public string Icon {
            get { 
               return _icon;
            }
            set {
                _icon = value;
            }
        }

        private string _EditIcon = "EditIcon";
        public string EditIcon {
            get
            {
                return _EditIcon;
            }
            set
            {
                _EditIcon = value;
            }
        }

        private string _DisplayName = "DisplayName";
         public string DisplayName {
            get
            {
                    return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }

        private string _name = "This is the discription";
         public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
                 
         public ObservableCollection<TreeNodeItem> Children { get; set; }
         public TreeNodeItem()
         {
             Children = new ObservableCollection<TreeNodeItem>();
         }      
     }
}
