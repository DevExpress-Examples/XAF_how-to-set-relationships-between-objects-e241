Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultClassOptions()> _
Public Class MasterObject
   Inherits XPObject
   Private fName As String
   Protected Overrides Sub OnSaving()
      MyBase.OnSaving()
   End Sub
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Property Name() As String
      Get
         Return fName
      End Get
      Set(ByVal value As String)
         SetPropertyValue("Name", fName, value)
      End Set
   End Property
   <Association("A-A"), Aggregated()> _
   Public ReadOnly Property AggregatedOneToManyCollection() As XPCollection(Of AggregatedOneToManyObject)
      Get
         Return GetCollection(Of AggregatedOneToManyObject)("AggregatedOneToManyCollection")
      End Get
   End Property
   <Association("B-B")> _
   Public ReadOnly Property NonAggregatedOneToManyCollection() _
         As XPCollection(Of NonAggregatedOneToManyObject)
      Get
         Return GetCollection(Of NonAggregatedOneToManyObject)("NonAggregatedOneToManyCollection")
      End Get
   End Property
   <Association("C-C")> _
   Public ReadOnly Property NonAggregatedManyToManyCollection() _
         As XPCollection(Of NonAggregatedManyToManyObject)
      Get
         Return GetCollection(Of NonAggregatedManyToManyObject)("NonAggregatedManyToManyCollection")
      End Get
   End Property
End Class
<DefaultClassOptions()> _
Public Class AggregatedOneToManyObject
   Inherits XPObject
   Private fName As String
   Private fMasterObject As MasterObject
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Property Name() As String
      Get
         Return fName
      End Get
      Set(ByVal value As String)
         SetPropertyValue("Name", fName, value)
      End Set
   End Property
   <Association("A-A")> _
   Public Property MasterObject() As MasterObject
      Get
         Return fMasterObject
      End Get
      Set(ByVal value As MasterObject)
         SetPropertyValue("MasterObject", fMasterObject, value)
      End Set
   End Property
End Class
<DefaultClassOptions()> _
Public Class NonAggregatedOneToManyObject
   Inherits XPObject
   Private fName As String
   Private fMasterObject As MasterObject
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Property Name() As String
      Get
         Return fName
      End Get
      Set(ByVal value As String)
         SetPropertyValue("Name", fName, value)
      End Set
   End Property
   <Association("B-B")> _
   Public Property MasterObject() As MasterObject
      Get
         Return fMasterObject
      End Get
      Set(ByVal value As MasterObject)
         SetPropertyValue("MasterObject", fMasterObject, value)
      End Set
   End Property
End Class
<DefaultClassOptions()> _
Public Class NonAggregatedManyToManyObject
   Inherits XPObject
   Private fName As String
   Protected Overrides Sub OnSaving()
      MyBase.OnSaving()
   End Sub
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Property Name() As String
      Get
         Return fName
      End Get
      Set(ByVal value As String)
         SetPropertyValue("Name", fName, value)
      End Set
   End Property
   <Association("C-C")> _
   Public ReadOnly Property MasterObjects() As XPCollection(Of MasterObject)
      Get
         Return GetCollection(Of MasterObject)("MasterObjects")
      End Get
   End Property
End Class