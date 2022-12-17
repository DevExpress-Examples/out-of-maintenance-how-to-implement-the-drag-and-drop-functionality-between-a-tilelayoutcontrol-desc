Imports DevExpress.Xpf.LayoutControl
Imports DevExpress.Xpf.Core
Imports System.Windows
Imports DevExpress.Xpf.Core.Native

Namespace TileLayoutControlDescendant

    Public Class TileLayoutCntrlDescendant
        Inherits TileLayoutControl

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function CreateController() As PanelControllerBase
            Return New TileLayoutDescendantController(Me)
        End Function
    End Class

    Public Class TileLayoutDescendantItemDragAndDropController
        Inherits TileLayoutItemDragAndDropController

        Public Sub New(ByVal controller As Controller, ByVal startDragPoint As Point, ByVal dragControl As FrameworkElement)
            MyBase.New(controller, startDragPoint, dragControl)
        End Sub

        Public Overrides Sub DragAndDrop(ByVal p As Point)
            Dim ctrl As FrameworkElement = Controller.Control
            If Not LayoutHelper.IsPointInsideElementBounds(p, ctrl, New Thickness()) Then
                DragControl.SetVisible(False)
                Dim dragData As DataObject = New DataObject("DragDropDataDG", DragControl.DataContext)
                DragDrop.DoDragDrop(ctrl, dragData, DragDropEffects.Copy)
                DragControl.SetVisible(True)
                Return
            End If

            MyBase.DragAndDrop(p)
        End Sub
    End Class

    Public Class TileLayoutDescendantController
        Inherits TileLayoutController

        Public Sub New(ByVal control As IFlowLayoutControl)
            MyBase.New(control)
        End Sub

        Protected Overrides Function CreateItemDragAndDropControler(ByVal startDragPoint As Point, ByVal dragControl As FrameworkElement) As DragAndDropController
            Return New TileLayoutDescendantItemDragAndDropController(Me, startDragPoint, dragControl)
        End Function
    End Class
End Namespace
