using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Core;
using System.Windows;
using DevExpress.Xpf.Core.Native;

namespace TileLayoutControlDescendant
{
    public class TileLayoutCntrlDescendant : TileLayoutControl 
    {
        public TileLayoutCntrlDescendant():base() { }
        protected override PanelControllerBase CreateController()
        {
            return new TileLayoutDescendantController(this);
        }
    }

    public class TileLayoutDescendantItemDragAndDropController : TileLayoutItemDragAndDropController
    {
        public TileLayoutDescendantItemDragAndDropController(Controller controller, Point startDragPoint, FrameworkElement dragControl): base(controller, startDragPoint, dragControl)
        {
            
        }

        public override void DragAndDrop(Point p)
        {
            FrameworkElement ctrl = this.Controller.Control;
            if (!LayoutHelper.IsPointInsideElementBounds(p, ctrl, new Thickness()))
            {
                DragControl.SetVisible(false);
                DataObject dragData = new DataObject("DragDropDataDG", DragControl.DataContext);
                DragDrop.DoDragDrop(ctrl, dragData, DragDropEffects.Copy);
                DragControl.SetVisible(true);
                return;
            } 
            base.DragAndDrop(p);
        }
    }

    public class TileLayoutDescendantController: TileLayoutController
    {
        public TileLayoutDescendantController(IFlowLayoutControl control) : base(control) { }

        protected override DragAndDropController CreateItemDragAndDropControler(Point startDragPoint, FrameworkElement dragControl)
        {
            return new TileLayoutDescendantItemDragAndDropController(this, startDragPoint, dragControl);
        }
    }
}
