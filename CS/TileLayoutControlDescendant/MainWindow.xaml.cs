using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;

namespace TileLayoutControlDescendant
{
    public partial class MainWindow : Window
    {
        int handler = GridControl.InvalidRowHandle;
        Point point;

        public MainWindow()
        {
            InitializeComponent();
            desc.ItemsSource = DataHelper.GetData1();
            gridControl1.ItemsSource = DataHelper.GetData2();
        }

        private void Dumping()
        {
            handler = GridControl.InvalidRowHandle;
            point = new Point(-1000, -1000);
        }

        private void gridControl1_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("DragDropDataDG"))
            {
                ((sender as GridControl).ItemsSource as ObservableCollection<ExampleObject>).Add((ExampleObject)e.Data.GetData("DragDropDataDG"));
            }
        }

        private void gridControl1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                point = e.GetPosition(null);
                GridControl grid = sender as GridControl;
                GridViewHitInfoBase info;
                CardView view = grid.View as CardView;

                info = view.CalcHitInfo(e.OriginalSource as DependencyObject);
                if (info.RowHandle != GridControl.InvalidRowHandle)
                {
                    handler = info.RowHandle;
                    e.Handled = true;
                }
            }
        }

        private void gridControl1_MouseMove(object sender, MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridViewBase view = grid.View as GridViewBase;
            Point mousePos = e.GetPosition(null);

            if (e.LeftButton != MouseButtonState.Pressed) return;
            if (handler == GridControl.InvalidRowHandle) return;

            Rect rect = new Rect(
                (point.X - SystemParameters.MinimumHorizontalDragDistance),
                (point.Y - (int)SystemParameters.MinimumVerticalDragDistance),
                SystemParameters.MinimumHorizontalDragDistance * 2,
                SystemParameters.MinimumVerticalDragDistance * 2);

            if (!rect.Contains(mousePos))
            {
                DataObject dragData = new DataObject("DragDropDataGD", (view.GetRowElementByRowHandle(handler).DataContext as RowData).Row);
                Dumping();
                DragDrop.DoDragDrop(grid, dragData, DragDropEffects.Copy);
            }
        }

        private void desc_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("DragDropDataGD"))
            {
                TileLayoutCntrlDescendant cntrl = sender as TileLayoutCntrlDescendant;
                (cntrl.ItemsSource as ObservableCollection<ExampleObject>).Add((ExampleObject)e.Data.GetData("DragDropDataGD"));
            }
        }
    }

}
