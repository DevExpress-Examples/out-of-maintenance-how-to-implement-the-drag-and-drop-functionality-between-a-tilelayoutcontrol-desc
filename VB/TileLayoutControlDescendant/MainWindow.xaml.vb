Imports System.Windows
Imports System.Windows.Input
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Grid

Namespace TileLayoutControlDescendant

    Public Partial Class MainWindow
        Inherits Window

        Private handler As Integer = DataControlBase.InvalidRowHandle

        Private point As Point

        Public Sub New()
            Me.InitializeComponent()
            Me.desc.ItemsSource = DataHelper.GetData1()
            Me.gridControl1.ItemsSource = DataHelper.GetData2()
        End Sub

        Private Sub Dumping()
            handler = DataControlBase.InvalidRowHandle
            point = New Point(-1000, -1000)
        End Sub

        Private Sub gridControl1_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data.GetDataPresent("DragDropDataDG") Then
                TryCast(TryCast(sender, GridControl).ItemsSource, ObservableCollection(Of ExampleObject)).Add(CType(e.Data.GetData("DragDropDataDG"), ExampleObject))
            End If
        End Sub

        Private Sub gridControl1_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If e.LeftButton = MouseButtonState.Pressed Then
                point = e.GetPosition(Nothing)
                Dim grid As GridControl = TryCast(sender, GridControl)
                Dim info As GridViewHitInfoBase
                Dim view As CardView = TryCast(grid.View, CardView)
                info = view.CalcHitInfo(TryCast(e.OriginalSource, DependencyObject))
                If info.RowHandle <> DataControlBase.InvalidRowHandle Then
                    handler = info.RowHandle
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub gridControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridViewBase = TryCast(grid.View, GridViewBase)
            Dim mousePos As Point = e.GetPosition(Nothing)
            If e.LeftButton <> MouseButtonState.Pressed Then Return
            If handler = DataControlBase.InvalidRowHandle Then Return
            Dim rect As Rect = New Rect(point.X - SystemParameters.MinimumHorizontalDragDistance, (point.Y - CInt(SystemParameters.MinimumVerticalDragDistance)), SystemParameters.MinimumHorizontalDragDistance * 2, SystemParameters.MinimumVerticalDragDistance * 2)
            If Not rect.Contains(mousePos) Then
                Dim dragData As DataObject = New DataObject("DragDropDataGD", TryCast(view.GetRowElementByRowHandle(handler).DataContext, RowData).Row)
                Dumping()
                DragDrop.DoDragDrop(grid, dragData, DragDropEffects.Copy)
            End If
        End Sub

        Private Sub desc_Drop(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data.GetDataPresent("DragDropDataGD") Then
                Dim cntrl As TileLayoutCntrlDescendant = TryCast(sender, TileLayoutCntrlDescendant)
                TryCast(cntrl.ItemsSource, ObservableCollection(Of ExampleObject)).Add(CType(e.Data.GetData("DragDropDataGD"), ExampleObject))
            End If
        End Sub
    End Class
End Namespace
