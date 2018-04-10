Imports movecam

Public MustInherit Class InjElement

    'Un InjElement rappresenta un percorso di iniezione lungo il quale la macchina si muove con ago abbassato
    'in un verso prefissato (dal primo all'ultimo nodo)
    'Non necessariamente l'iniezione avviene per tutto il percorso
    'Un InjElement puo' essere formato:
    'da 1 (e 1 solo) punto (InjPoint)
    'da 1 o piu' Path connessi tra loro da un segmento (eventualmente di lunghezza 0) tra i due punti estremi
    'un Path (composto da 1 o piu' segmenti) è direttamente associato ad una figura di controllo, e puo' essere:
    ' - spezzata (il percorso e il controllo coincidono)
    ' - arco di cerchio 
    ' - Bspline (spline cubica con linea di controllo esterna)
    ' - BControlSpline (spline cubica con linea di controllo che passa per la spline)


    Protected _inj As Injector
    Protected _selected As Boolean
    Protected ctrlPoint As List(Of ControlPoint)
    Protected injPoint As List(Of InjPoint)
    Private currentControlPoint As Integer = -1
    Private currentInjPoint As Integer = -1

    Public MustOverride Sub draw(gc As GraphicContest)
    Public MustOverride Function getSelectedPoint() As xyPoint
    Public MustOverride Sub moveSelectedPoint(p As MousePoint)
    Public MustOverride Function findPoint(p As MousePoint) As xyPoint
    Public MustOverride Function addPoint(p As MousePoint) As Boolean


    Public Property Inj As Injector 'Implements InjPath.Inj
        Get
            Return _inj
        End Get
        Set(value As Injector)
            _inj = value
        End Set
    End Property

    Public Property Selected As Boolean 'Implements InjPath.Selected
        Get
            Return _selected
        End Get
        Set(value As Boolean)
            _selected = value
        End Set
    End Property

    Public Sub drawInjPath(gc As GraphicContest)
        Dim cpPen As Pen = New Pen(Inj.Colore)

        Dim ns As Integer = 0
        Dim p1, p2 As Point

        p1 = injPoint(0).P
        Dim pi As xyPoint
        pi = New InjPoint(p1, True, True)
        pi.draw(gc, Inj)
        If injPoint IsNot Nothing Then
            For ns = 1 To injPoint.Count - 1
                p2 = injPoint(ns).P
                gc.G.DrawLine(cpPen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))
                pi = New InjPoint(p2, True, True)
                pi.draw(gc, Inj)
                p1 = p2
            Next
        End If
    End Sub

    Public Overridable Function getFirstCtrlPoint() As ControlPoint
        If ctrlPoint IsNot Nothing Then
            currentControlPoint = 0
            Return ctrlPoint.First()
        End If
        currentControlPoint = -1
        Return Nothing
    End Function
    Public Overridable Function getLastCtrlPoint() As ControlPoint
        If ctrlPoint IsNot Nothing Then
            currentControlPoint = ctrlPoint.Count - 1
            Return ctrlPoint.Last()
        End If
        currentControlPoint = -1
        Return Nothing
    End Function
    Public Overridable Function getCtrlPointN(nPoint As Integer) As ControlPoint
        If ctrlPoint IsNot Nothing And nPoint >= 0 And nPoint < ctrlPoint.Count Then
            Return ctrlPoint(nPoint)
        End If
        currentControlPoint = -1
        Return Nothing
    End Function

    Public Overridable Function getCurrentCtrlPoint() As ControlPoint
        Return getCtrlPointN(currentControlPoint)
    End Function

    Public Overridable Function getPreviousCtrlPoint() As ControlPoint
        currentControlPoint = currentControlPoint - 1
        Return getCurrentCtrlPoint()
    End Function

    Public Overridable Function getNextCtrlPoint() As ControlPoint
        currentControlPoint = currentControlPoint + 1
        Return getCurrentCtrlPoint()
    End Function

    Public Overridable Function isLastCtrlPoint() As Boolean
        Return currentControlPoint = ctrlPoint.Count - 1
    End Function

    Public Overridable Function getFirstInjPoint() As InjPoint
        If injPoint IsNot Nothing Then
            currentInjPoint = 0
            Return injPoint.First()
        End If
        currentInjPoint = -1
        Return Nothing
    End Function
    Public Overridable Function getLastInjPoint() As InjPoint
        If injPoint IsNot Nothing Then
            currentInjPoint = injPoint.Count - 1
            Return injPoint.Last()
        End If
        currentInjPoint = -1
        Return Nothing
    End Function
    Public Overridable Function getInjPointN(nPoint As Integer) As InjPoint
        If injPoint IsNot Nothing And nPoint >= 0 And nPoint < injPoint.Count Then
            Return injPoint(nPoint)
        End If
        currentInjPoint = -1
        Return Nothing
    End Function

    Public Overridable Function getCurrentInjPoint() As InjPoint
        Return getInjPointN(currentInjPoint)
    End Function

    Public Overridable Function getPreviousInjPoint() As InjPoint
        currentInjPoint = currentInjPoint - 1
        Return getCurrentInjPoint()
    End Function

    Public Overridable Function getNextInjPoint() As InjPoint
        currentInjPoint = currentInjPoint + 1
        Return getCurrentInjPoint()
    End Function

    Public Overridable Function isLastInjPoint() As Boolean
        Return currentInjPoint = injPoint.Count - 1
    End Function

    Public Function getCurrentInjPointTableIcon() As Image
        If currentInjPoint = 0 Then
            If isLastInjPoint() Then
                Return My.Resources.InjectSinglePoint
            End If
        End If
        Return My.Resources.injPoint
    End Function


End Class
