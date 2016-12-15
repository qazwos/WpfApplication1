using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MyMVVM;
using WpfApplication2;
using System.Collections.ObjectModel;
using System.Data;

namespace WpfApplication2
{
  public  class MainViewModel : NotifyObject
    {
        public MainViewModel()
        {
            ShowTreeView();
            showListItem();
        }

        private void showListItem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Columns.Add("c");
            dt.Columns.Add("d");
            dt.Columns.Add("e");
            dt.Columns.Add("f");
            dt.Columns.Add("g");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dr[i] = i.ToString();
            }
            dt.Rows.Add(dr );
            this.showList = dt;
        }

        private ObservableCollection<TreeNodeItem> _itemList;
        public ObservableCollection<TreeNodeItem> itemList
        {
            get {
                if (_itemList == null)
                {
                    _itemList= new ObservableCollection<TreeNodeItem>(); 
                } return _itemList;
            }
            set { _itemList = value;
                RaisePropertyChanged("_itemList");
            }
        }

        private DataTable _showList;
        public DataTable showList
        {
            get
            {
                if (_showList == null)
                {
                    _showList = new DataTable();
                }
                return _showList;
            }
            set
            {
                _showList = value;
                RaisePropertyChanged("_showList");
            }
        }


        private void ShowTreeView()
        {
            TreeNodeItem node1 = new TreeNodeItem()
            {
                DisplayName = "任务运行区",
                Children = new ObservableCollection<TreeNodeItem>()
                {
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.1"
                    },
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.2"
                    }
                    ,
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.3"
                    }
                }
            };
            itemList.Add(node1);
            TreeNodeItem node2 = new TreeNodeItem()
            {
                DisplayName = "任务执行计划",
                Children = new ObservableCollection<TreeNodeItem>()
                {
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.1"
                    },
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.2"
                    }
                    ,
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.3"
                    }
                }
            };
            itemList.Add(node2);
            TreeNodeItem node3 = new TreeNodeItem()
            {
                DisplayName = "任务分类",
                Children = new ObservableCollection<TreeNodeItem>()
                {
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.1"
                    },
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.2"
                    }
                    ,
                    new TreeNodeItem()
                    {
                        DisplayName = "Tag No.3"
                    }
                }
            };
            itemList.Add(node3);
            //  this.tvProperties.ItemsSource = itemList;
        }


        private string _tipText;
        public string TipText
        {
            get { return _tipText; }
            set
            {
                _tipText = value;
                RaisePropertyChanged("TipText");
            }
        }

 
        private MyCommand _MenuItem_tuichu;
        public MyCommand MenuItem_tuichu
        {
            get
            {
                if (_MenuItem_tuichu == null)
                    _MenuItem_tuichu = new MyCommand(
                        new Action<object>(
                            o =>
                            {
                                if (MessageBox.Show("是否退出？", "警告", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                {
                                    Application.Current.Shutdown();
                                }
                                
                            }
                            ));
                return _MenuItem_tuichu;
            }
        }


        private MyCommand _ClickCommand;
        public MyCommand ClickCommand
        {
            get
            {
                if (_ClickCommand == null)
                    _ClickCommand = new MyCommand(
                        new Action<object>(
                            o =>
                           {
                               MessageBox.Show("程序加载完毕！");
                               itemList[0].Children.Add(new TreeNodeItem()
                               {
                                   DisplayName = "add "
                               });

                               DataRow dr = this.showList.NewRow();
                               for (int i = 0; i < this.showList.Columns.Count; i++)
                               {
                                   dr[i] = i.ToString();
                               }
                               this.showList.Rows.Add(dr);
                           }
                            ));
                return _ClickCommand;
            }
        }

        private MyCommand<System.Windows.Input.MouseEventArgs> _mouseMoveCommand;
        public MyCommand<MouseEventArgs> MouseMoveCommand
        {
            get
            {
                if (_mouseMoveCommand == null)
                    _mouseMoveCommand = new MyCommand<MouseEventArgs>(
                        new Action<MouseEventArgs>(e =>
                        {
                            var point = e.GetPosition(e.Device.Target);
                            var left = "左键放开";
                            var mid = "中键放开";
                            var right = "右键放开";

                            if (e.LeftButton == MouseButtonState.Pressed)
                                left = "左键按下";
                            if (e.MiddleButton == MouseButtonState.Pressed)
                                mid = "中键按下";
                            if (e.RightButton == MouseButtonState.Pressed)
                                right = "右键按下";

                            TipText = $"当前鼠标位置  X:{point.X}  Y:{point.Y}  当前鼠标状态:{left} {mid}  {right}";
                        }));
                return _mouseMoveCommand;
            }
        }

    }
}
