<!-- default file list -->
*Files to look at*:

* [DataHelper.cs](./CS/TileLayoutControlDescendant/DataHelper.cs) (VB: [DataHelper.vb](./VB/TileLayoutControlDescendant/DataHelper.vb))
* [MainWindow.xaml](./CS/TileLayoutControlDescendant/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/TileLayoutControlDescendant/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/TileLayoutControlDescendant/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/TileLayoutControlDescendant/MainWindow.xaml.vb))
* [TileLayoutCntrlDescendant.cs](./CS/TileLayoutControlDescendant/TileLayoutCntrlDescendant.cs) (VB: [TileLayoutCntrlDescendant.vb](./VB/TileLayoutControlDescendant/TileLayoutCntrlDescendant.vb))
<!-- default file list end -->
# How to implement the drag-and-drop functionality between a TileLayoutControl descendant and GridControl


<p>This example demonstrates how to implement the drag-and-drop functionality between a TileLayoutControl descendant and GridControl. </p><p>This is an extended variant of the <a href="https://www.devexpress.com/Support/Center/p/E4303">E4303: How to implement the drag-and-drop functionality between TileLayoutControl and GridControl by using standard methods</a> example. Unlike the <a href="https://www.devexpress.com/Support/Center/p/E4303">E4303</a> example, there is no need to disable the AllowItemMoving property since the drag-and-drop functionality is implemented based on the inner functionality of a TileLayoutControl. When you drag a tile outside the control bounds, the standard drag-and-drop functionality is enabled, so that you can drop a tile to any other control using the standard WPF approach.</p>

<br/>


