using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace HowToSetRelationshipsBetweenObjects.Module {
	[DefaultClassOptions]
	public class MasterObject : XPObject {
		private String name;
		protected override void OnSaving() {
			base.OnSaving();
		}
		public MasterObject(Session session) : base(session) {
		}
		public String Name {
			get {
				return name;
			}
			set {
				SetPropertyValue("Name", ref name, value);
			}
		}
		[Association("A-A"), Aggregated]
		public XPCollection<AggregatedOneToManyObject> AggregatedOneToManyCollection {
			get {
				return GetCollection<AggregatedOneToManyObject>("AggregatedOneToManyCollection");
			}
		}
		[Association("B-B")]
		public XPCollection<NonAggregatedOneToManyObject> NonAggregatedOneToManyCollection {
			get {
				return GetCollection<NonAggregatedOneToManyObject>("NonAggregatedOneToManyCollection");
			}
		}
		[Association("C-C")]
		public XPCollection<NonAggregatedManyToManyObject> NonAggregatedManyToManyCollection {
			get {
				return GetCollection<NonAggregatedManyToManyObject>("NonAggregatedManyToManyCollection");
			}
		}
	}

	[DefaultClassOptions]
	public class AggregatedOneToManyObject : XPObject {
		private String name;
		private MasterObject masterObject;
		public AggregatedOneToManyObject(Session session) : base(session) {
		}
		public String Name {
			get {
				return name;
			}
			set {
				SetPropertyValue("Name", ref name, value);
			}
		}
		[Association("A-A")]
		public MasterObject MasterObject {
			get {
				return masterObject;
			}
			set {
				SetPropertyValue("MasterObject", ref masterObject, value);
			}
		}
	}

	[DefaultClassOptions]
	public class NonAggregatedOneToManyObject : XPObject {
		private String name;
		private MasterObject masterObject;
		public NonAggregatedOneToManyObject(Session session) : base(session) {
		}
		public String Name {
			get {
				return name;
			}
			set {
				SetPropertyValue("Name", ref name, value);
			}
		}
		[Association("B-B")]
		public MasterObject MasterObject {
			get {
				return masterObject;
			}
			set {
				SetPropertyValue("MasterObject", ref masterObject, value);
			}
		}
	}

	[DefaultClassOptions]
	public class NonAggregatedManyToManyObject : XPObject {
		private String name;
		protected override void OnSaving() {
			base.OnSaving();
		}
		public NonAggregatedManyToManyObject(Session session) : base(session) {
		}
		public String Name {
			get {
				return name;
			}
			set {
				SetPropertyValue("Name", ref name, value);
			}
		}
		[Association("C-C")]
		public XPCollection<MasterObject> MasterObjects {
			get {
				return GetCollection<MasterObject>("MasterObjects");
			}
		}
	}
}
