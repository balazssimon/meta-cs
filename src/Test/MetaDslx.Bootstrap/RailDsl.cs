using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RailDsl
{
	using global::RailDsl.Internal;

	internal class RailDslMetaModel : global::MetaDslx.Modeling.IMetaModel
	{
		internal RailDslMetaModel()
		{
		}
	
		public global::MetaDslx.Modeling.ModelId Id => RailDslInstance.MModel.Id;
		public string Name => "RailDsl";
		public global::MetaDslx.Modeling.ModelVersion Version => RailDslInstance.MModel.Version;
		public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => RailDslInstance.MModel.Objects;
		public string Uri => "http://www.bme.hu/iit/vke/raildsl";
		public string Prefix => "railDsl";
		public global::MetaDslx.Modeling.IModelGroup ModelGroup => RailDslInstance.MModel.ModelGroup;
		public string Namespace => "RailDsl";
	
		public global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new RailDslFactory(model, flags);
		}
	
	    public override string ToString()
	    {
	        return $"{Name} ({Version})";
	    }
	}

	public class RailDslInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return RailDslInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Modeling.IMetaModel MMetaModel;
		public static readonly global::MetaDslx.Modeling.ImmutableModel MModel;
	
	
		public static readonly global::.MetaClass Station;
		public static readonly global::.MetaProperty Station_Declarations;
		public static readonly global::.MetaClass Declaration;
		public static readonly global::.MetaClass TrackObject;
		public static readonly global::.MetaProperty TrackObject_Length;
		public static readonly global::.MetaClass Vertex;
		public static readonly global::.MetaProperty Vertex_Kind;
		public static readonly global::.MetaClass Segment;
		public static readonly global::.MetaProperty Segment_Start;
		public static readonly global::.MetaProperty Segment_End;
		public static readonly global::.MetaProperty Segment_Objects;
		public static readonly global::.MetaClass SegmentObject;
		public static readonly global::.MetaProperty SegmentObject_Position;
		public static readonly global::.MetaClass Derailer;
		public static readonly global::.MetaProperty Derailer_Active;
		public static readonly global::.MetaClass LevelCrossing;
		public static readonly global::.MetaProperty LevelCrossing_Closed;
		public static readonly global::.MetaProperty LevelCrossing_Length;
		public static readonly global::.MetaClass Signal;
		public static readonly global::.MetaProperty Signal_DistantFor;
		public static readonly global::.MetaProperty Signal_Main;
		public static readonly global::.MetaProperty Signal_Shunting;
		public static readonly global::.MetaClass Platform;
		public static readonly global::.MetaProperty Platform_Length;
		public static readonly global::.MetaClass SegmentPosition;
		public static readonly global::.MetaProperty SegmentPosition_AtStart;
		public static readonly global::.MetaProperty SegmentPosition_AtEnd;
		public static readonly global::.MetaProperty SegmentPosition_Position;
		public static readonly global::.MetaProperty SegmentPosition_Side;
		public static readonly global::.MetaProperty SegmentPosition_Orientation;
		public static readonly global::.MetaProperty SegmentPosition_Segment;
		public static readonly global::.MetaClass Point;
		public static readonly global::.MetaProperty Point_Inputs;
		public static readonly global::.MetaProperty Point_Outputs;
		public static readonly global::.MetaProperty Point_Kind;
		public static readonly global::.MetaProperty Point_SelectedInput;
		public static readonly global::.MetaProperty Point_SelectedOutput;
		public static readonly global::.MetaProperty Point_Locked;
		public static readonly global::.MetaClass Track;
		public static readonly global::.MetaProperty Track_Elements;
		public static readonly global::.MetaClass NamedElement;
		public static readonly global::.MetaProperty NamedElement_Name;
		public static readonly global::.MetaClass Train;
		public static readonly global::.MetaProperty Train_Length;
		public static readonly global::.MetaProperty Train_Speed;
		public static readonly global::.MetaProperty Train_Segments;
		public static readonly global::.MetaProperty Train_Position;
		public static readonly global::.MetaProperty Train_Acceleration;
		public static readonly global::.MetaClass TrainSegment;
		public static readonly global::.MetaProperty TrainSegment_Position;
		public static readonly global::.MetaProperty TrainSegment_Length;
		public static readonly global::.MetaClass RouteObject;
		public static readonly global::.MetaProperty RouteObject_SpeedLimit;
		public static readonly global::.MetaProperty RouteObject_Error;
		public static readonly global::.MetaClass TrainRoute;
		public static readonly global::.MetaProperty TrainRoute_Path;
		public static readonly global::.MetaProperty TrainRoute_Kind;
		public static readonly global::.MetaProperty TrainRoute_StartSignal;
		public static readonly global::.MetaProperty TrainRoute_EndSignal;
		public static readonly global::.MetaProperty TrainRoute_ProtectionObjects;
		public static readonly global::.MetaProperty TrainRoute_ConflictingRoutes;
		public static readonly global::.MetaProperty TrainRoute_Locked;
		public static readonly global::.MetaClass TrainRouteObject;
		public static readonly global::.MetaProperty TrainRouteObject_SpeedLimit;
		public static readonly global::.MetaClass TrainRoutePoint;
		public static readonly global::.MetaProperty TrainRoutePoint_OriginalPoint;
		public static readonly global::.MetaProperty TrainRoutePoint_SelectedInput;
		public static readonly global::.MetaProperty TrainRoutePoint_SelectedOutput;
		public static readonly global::.MetaClass TrainRouteSegment;
		public static readonly global::.MetaProperty TrainRouteSegment_OriginalSegment;
	
		static RailDslInstance()
		{
			RailDslBuilderInstance.instance.Create();
			RailDslBuilderInstance.instance.EvaluateLazyValues();
			MMetaModel = new RailDslMetaModel();
			MModel = RailDslBuilderInstance.instance.MModel.ToImmutable();
	
	
			Station = RailDslBuilderInstance.instance.Station.ToImmutable(MModel);
			Station_Declarations = RailDslBuilderInstance.instance.Station_Declarations.ToImmutable(MModel);
			Declaration = RailDslBuilderInstance.instance.Declaration.ToImmutable(MModel);
			TrackObject = RailDslBuilderInstance.instance.TrackObject.ToImmutable(MModel);
			TrackObject_Length = RailDslBuilderInstance.instance.TrackObject_Length.ToImmutable(MModel);
			Vertex = RailDslBuilderInstance.instance.Vertex.ToImmutable(MModel);
			Vertex_Kind = RailDslBuilderInstance.instance.Vertex_Kind.ToImmutable(MModel);
			Segment = RailDslBuilderInstance.instance.Segment.ToImmutable(MModel);
			Segment_Start = RailDslBuilderInstance.instance.Segment_Start.ToImmutable(MModel);
			Segment_End = RailDslBuilderInstance.instance.Segment_End.ToImmutable(MModel);
			Segment_Objects = RailDslBuilderInstance.instance.Segment_Objects.ToImmutable(MModel);
			SegmentObject = RailDslBuilderInstance.instance.SegmentObject.ToImmutable(MModel);
			SegmentObject_Position = RailDslBuilderInstance.instance.SegmentObject_Position.ToImmutable(MModel);
			Derailer = RailDslBuilderInstance.instance.Derailer.ToImmutable(MModel);
			Derailer_Active = RailDslBuilderInstance.instance.Derailer_Active.ToImmutable(MModel);
			LevelCrossing = RailDslBuilderInstance.instance.LevelCrossing.ToImmutable(MModel);
			LevelCrossing_Closed = RailDslBuilderInstance.instance.LevelCrossing_Closed.ToImmutable(MModel);
			LevelCrossing_Length = RailDslBuilderInstance.instance.LevelCrossing_Length.ToImmutable(MModel);
			Signal = RailDslBuilderInstance.instance.Signal.ToImmutable(MModel);
			Signal_DistantFor = RailDslBuilderInstance.instance.Signal_DistantFor.ToImmutable(MModel);
			Signal_Main = RailDslBuilderInstance.instance.Signal_Main.ToImmutable(MModel);
			Signal_Shunting = RailDslBuilderInstance.instance.Signal_Shunting.ToImmutable(MModel);
			Platform = RailDslBuilderInstance.instance.Platform.ToImmutable(MModel);
			Platform_Length = RailDslBuilderInstance.instance.Platform_Length.ToImmutable(MModel);
			SegmentPosition = RailDslBuilderInstance.instance.SegmentPosition.ToImmutable(MModel);
			SegmentPosition_AtStart = RailDslBuilderInstance.instance.SegmentPosition_AtStart.ToImmutable(MModel);
			SegmentPosition_AtEnd = RailDslBuilderInstance.instance.SegmentPosition_AtEnd.ToImmutable(MModel);
			SegmentPosition_Position = RailDslBuilderInstance.instance.SegmentPosition_Position.ToImmutable(MModel);
			SegmentPosition_Side = RailDslBuilderInstance.instance.SegmentPosition_Side.ToImmutable(MModel);
			SegmentPosition_Orientation = RailDslBuilderInstance.instance.SegmentPosition_Orientation.ToImmutable(MModel);
			SegmentPosition_Segment = RailDslBuilderInstance.instance.SegmentPosition_Segment.ToImmutable(MModel);
			Point = RailDslBuilderInstance.instance.Point.ToImmutable(MModel);
			Point_Inputs = RailDslBuilderInstance.instance.Point_Inputs.ToImmutable(MModel);
			Point_Outputs = RailDslBuilderInstance.instance.Point_Outputs.ToImmutable(MModel);
			Point_Kind = RailDslBuilderInstance.instance.Point_Kind.ToImmutable(MModel);
			Point_SelectedInput = RailDslBuilderInstance.instance.Point_SelectedInput.ToImmutable(MModel);
			Point_SelectedOutput = RailDslBuilderInstance.instance.Point_SelectedOutput.ToImmutable(MModel);
			Point_Locked = RailDslBuilderInstance.instance.Point_Locked.ToImmutable(MModel);
			Track = RailDslBuilderInstance.instance.Track.ToImmutable(MModel);
			Track_Elements = RailDslBuilderInstance.instance.Track_Elements.ToImmutable(MModel);
			NamedElement = RailDslBuilderInstance.instance.NamedElement.ToImmutable(MModel);
			NamedElement_Name = RailDslBuilderInstance.instance.NamedElement_Name.ToImmutable(MModel);
			Train = RailDslBuilderInstance.instance.Train.ToImmutable(MModel);
			Train_Length = RailDslBuilderInstance.instance.Train_Length.ToImmutable(MModel);
			Train_Speed = RailDslBuilderInstance.instance.Train_Speed.ToImmutable(MModel);
			Train_Segments = RailDslBuilderInstance.instance.Train_Segments.ToImmutable(MModel);
			Train_Position = RailDslBuilderInstance.instance.Train_Position.ToImmutable(MModel);
			Train_Acceleration = RailDslBuilderInstance.instance.Train_Acceleration.ToImmutable(MModel);
			TrainSegment = RailDslBuilderInstance.instance.TrainSegment.ToImmutable(MModel);
			TrainSegment_Position = RailDslBuilderInstance.instance.TrainSegment_Position.ToImmutable(MModel);
			TrainSegment_Length = RailDslBuilderInstance.instance.TrainSegment_Length.ToImmutable(MModel);
			RouteObject = RailDslBuilderInstance.instance.RouteObject.ToImmutable(MModel);
			RouteObject_SpeedLimit = RailDslBuilderInstance.instance.RouteObject_SpeedLimit.ToImmutable(MModel);
			RouteObject_Error = RailDslBuilderInstance.instance.RouteObject_Error.ToImmutable(MModel);
			TrainRoute = RailDslBuilderInstance.instance.TrainRoute.ToImmutable(MModel);
			TrainRoute_Path = RailDslBuilderInstance.instance.TrainRoute_Path.ToImmutable(MModel);
			TrainRoute_Kind = RailDslBuilderInstance.instance.TrainRoute_Kind.ToImmutable(MModel);
			TrainRoute_StartSignal = RailDslBuilderInstance.instance.TrainRoute_StartSignal.ToImmutable(MModel);
			TrainRoute_EndSignal = RailDslBuilderInstance.instance.TrainRoute_EndSignal.ToImmutable(MModel);
			TrainRoute_ProtectionObjects = RailDslBuilderInstance.instance.TrainRoute_ProtectionObjects.ToImmutable(MModel);
			TrainRoute_ConflictingRoutes = RailDslBuilderInstance.instance.TrainRoute_ConflictingRoutes.ToImmutable(MModel);
			TrainRoute_Locked = RailDslBuilderInstance.instance.TrainRoute_Locked.ToImmutable(MModel);
			TrainRouteObject = RailDslBuilderInstance.instance.TrainRouteObject.ToImmutable(MModel);
			TrainRouteObject_SpeedLimit = RailDslBuilderInstance.instance.TrainRouteObject_SpeedLimit.ToImmutable(MModel);
			TrainRoutePoint = RailDslBuilderInstance.instance.TrainRoutePoint.ToImmutable(MModel);
			TrainRoutePoint_OriginalPoint = RailDslBuilderInstance.instance.TrainRoutePoint_OriginalPoint.ToImmutable(MModel);
			TrainRoutePoint_SelectedInput = RailDslBuilderInstance.instance.TrainRoutePoint_SelectedInput.ToImmutable(MModel);
			TrainRoutePoint_SelectedOutput = RailDslBuilderInstance.instance.TrainRoutePoint_SelectedOutput.ToImmutable(MModel);
			TrainRouteSegment = RailDslBuilderInstance.instance.TrainRouteSegment.ToImmutable(MModel);
			TrainRouteSegment_OriginalSegment = RailDslBuilderInstance.instance.TrainRouteSegment_OriginalSegment.ToImmutable(MModel);
	
			RailDslInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class RailDslFactory : global::MetaDslx.Modeling.ModelFactoryBase
	{
		public RailDslFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			RailDslDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel => global::RailDsl.RailDslInstance.MMetaModel;
	
		public override global::MetaDslx.Modeling.MutableObject Create(string type)
		{
			switch (type)
			{
				case "Station": return this.Station();
				case "Declaration": return this.Declaration();
				case "TrackObject": return this.TrackObject();
				case "Vertex": return this.Vertex();
				case "Segment": return this.Segment();
				case "SegmentObject": return this.SegmentObject();
				case "Derailer": return this.Derailer();
				case "LevelCrossing": return this.LevelCrossing();
				case "Signal": return this.Signal();
				case "Platform": return this.Platform();
				case "SegmentPosition": return this.SegmentPosition();
				case "Point": return this.Point();
				case "Track": return this.Track();
				case "NamedElement": return this.NamedElement();
				case "Train": return this.Train();
				case "TrainSegment": return this.TrainSegment();
				case "RouteObject": return this.RouteObject();
				case "TrainRoute": return this.TrainRoute();
				case "TrainRouteObject": return this.TrainRouteObject();
				case "TrainRoutePoint": return this.TrainRoutePoint();
				case "TrainRouteSegment": return this.TrainRouteSegment();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Station.
		/// </summary>
		public StationBuilder Station()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new StationId());
			return (StationBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Declaration.
		/// </summary>
		public DeclarationBuilder Declaration()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new DeclarationId());
			return (DeclarationBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of TrackObject.
		/// </summary>
		public TrackObjectBuilder TrackObject()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrackObjectId());
			return (TrackObjectBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Vertex.
		/// </summary>
		public VertexBuilder Vertex()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new VertexId());
			return (VertexBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Segment.
		/// </summary>
		public SegmentBuilder Segment()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new SegmentId());
			return (SegmentBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of SegmentObject.
		/// </summary>
		public SegmentObjectBuilder SegmentObject()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new SegmentObjectId());
			return (SegmentObjectBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Derailer.
		/// </summary>
		public DerailerBuilder Derailer()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new DerailerId());
			return (DerailerBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LevelCrossing.
		/// </summary>
		public LevelCrossingBuilder LevelCrossing()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LevelCrossingId());
			return (LevelCrossingBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Signal.
		/// </summary>
		public SignalBuilder Signal()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new SignalId());
			return (SignalBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Platform.
		/// </summary>
		public PlatformBuilder Platform()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new PlatformId());
			return (PlatformBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of SegmentPosition.
		/// </summary>
		public SegmentPositionBuilder SegmentPosition()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new SegmentPositionId());
			return (SegmentPositionBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Point.
		/// </summary>
		public PointBuilder Point()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new PointId());
			return (PointBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Track.
		/// </summary>
		public TrackBuilder Track()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrackId());
			return (TrackBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of NamedElement.
		/// </summary>
		public NamedElementBuilder NamedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new NamedElementId());
			return (NamedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Train.
		/// </summary>
		public TrainBuilder Train()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrainId());
			return (TrainBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of TrainSegment.
		/// </summary>
		public TrainSegmentBuilder TrainSegment()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrainSegmentId());
			return (TrainSegmentBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of RouteObject.
		/// </summary>
		public RouteObjectBuilder RouteObject()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new RouteObjectId());
			return (RouteObjectBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of TrainRoute.
		/// </summary>
		public TrainRouteBuilder TrainRoute()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrainRouteId());
			return (TrainRouteBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of TrainRouteObject.
		/// </summary>
		public TrainRouteObjectBuilder TrainRouteObject()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrainRouteObjectId());
			return (TrainRouteObjectBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of TrainRoutePoint.
		/// </summary>
		public TrainRoutePointBuilder TrainRoutePoint()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrainRoutePointId());
			return (TrainRoutePointBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of TrainRouteSegment.
		/// </summary>
		public TrainRouteSegmentBuilder TrainRouteSegment()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new TrainRouteSegmentId());
			return (TrainRouteSegmentBuilder)obj;
		}
	}
	

	
	public enum SpeedLimit
	{
		Stop,
		Speed40,
		Speed80,
		Speed120,
		Max
	}
	
	public static class SpeedLimitExtensions
	{
	}
	
	public enum PointKind
	{
		FixedCrossing,
		SimplePoint,
		DoublePoint,
		SingleSlipPoint,
		DoubleSlipPoint
	}
	
	public static class PointKindExtensions
	{
	}
	
	public enum VertexKind
	{
		InnerVertex,
		TrackEnd,
		StationBorder
	}
	
	public static class VertexKindExtensions
	{
	}
	
	public enum Orientation
	{
		Forwards,
		Backwards
	}
	
	public static class OrientationExtensions
	{
	}
	
	public enum Side
	{
		Both,
		Right,
		Left
	}
	
	public static class SideExtensions
	{
	}
	
	public enum TrainRouteKind
	{
		Main,
		Shunting
	}
	
	public static class TrainRouteKindExtensions
	{
	}
	
	public interface Station : NamedElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Station"/> object to a builder <see cref="StationBuilder"/> object.
		/// </summary>
		new StationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Station"/> object to a builder <see cref="StationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new StationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface StationBuilder : NamedElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="StationBuilder"/> object to an immutable <see cref="Station"/> object.
		/// </summary>
		new Station ToImmutable();
		/// <summary>
		/// Convert the <see cref="StationBuilder"/> object to an immutable <see cref="Station"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Station ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Declaration : NamedElement
	{
	
	
		/// <summary>
		/// Convert the <see cref="Declaration"/> object to a builder <see cref="DeclarationBuilder"/> object.
		/// </summary>
		new DeclarationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Declaration"/> object to a builder <see cref="DeclarationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new DeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DeclarationBuilder : NamedElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="DeclarationBuilder"/> object to an immutable <see cref="Declaration"/> object.
		/// </summary>
		new Declaration ToImmutable();
		/// <summary>
		/// Convert the <see cref="DeclarationBuilder"/> object to an immutable <see cref="Declaration"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Declaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TrackObject : Declaration, RouteObject
	{
		double Length { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrackObject"/> object to a builder <see cref="TrackObjectBuilder"/> object.
		/// </summary>
		new TrackObjectBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="TrackObject"/> object to a builder <see cref="TrackObjectBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrackObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrackObjectBuilder : DeclarationBuilder, RouteObjectBuilder
	{
		double Length { get; set; }
		void SetLengthLazy(global::System.Func<double> lazy);
		void SetLengthLazy(global::System.Func<TrackObjectBuilder, double> lazy);
		void SetLengthLazy(global::System.Func<TrackObject, double> immutableLazy, global::System.Func<TrackObjectBuilder, double> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrackObjectBuilder"/> object to an immutable <see cref="TrackObject"/> object.
		/// </summary>
		new TrackObject ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrackObjectBuilder"/> object to an immutable <see cref="TrackObject"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new TrackObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Vertex : Declaration
	{
		VertexKind Kind { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Vertex"/> object to a builder <see cref="VertexBuilder"/> object.
		/// </summary>
		new VertexBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Vertex"/> object to a builder <see cref="VertexBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new VertexBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface VertexBuilder : DeclarationBuilder
	{
		VertexKind Kind { get; set; }
		void SetKindLazy(global::System.Func<VertexKind> lazy);
		void SetKindLazy(global::System.Func<VertexBuilder, VertexKind> lazy);
		void SetKindLazy(global::System.Func<Vertex, VertexKind> immutableLazy, global::System.Func<VertexBuilder, VertexKind> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="VertexBuilder"/> object to an immutable <see cref="Vertex"/> object.
		/// </summary>
		new Vertex ToImmutable();
		/// <summary>
		/// Convert the <see cref="VertexBuilder"/> object to an immutable <see cref="Vertex"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Vertex ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Segment : TrackObject
	{
		Vertex Start { get; }
		Vertex End { get; }
		global::MetaDslx.Modeling.ImmutableModelList<SegmentObject> Objects { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Segment"/> object to a builder <see cref="SegmentBuilder"/> object.
		/// </summary>
		new SegmentBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Segment"/> object to a builder <see cref="SegmentBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new SegmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface SegmentBuilder : TrackObjectBuilder
	{
		VertexBuilder Start { get; set; }
		void SetStartLazy(global::System.Func<VertexBuilder> lazy);
		void SetStartLazy(global::System.Func<SegmentBuilder, VertexBuilder> lazy);
		void SetStartLazy(global::System.Func<Segment, Vertex> immutableLazy, global::System.Func<SegmentBuilder, VertexBuilder> mutableLazy);
		VertexBuilder End { get; set; }
		void SetEndLazy(global::System.Func<VertexBuilder> lazy);
		void SetEndLazy(global::System.Func<SegmentBuilder, VertexBuilder> lazy);
		void SetEndLazy(global::System.Func<Segment, Vertex> immutableLazy, global::System.Func<SegmentBuilder, VertexBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<SegmentObjectBuilder> Objects { get; }
	
	
		/// <summary>
		/// Convert the <see cref="SegmentBuilder"/> object to an immutable <see cref="Segment"/> object.
		/// </summary>
		new Segment ToImmutable();
		/// <summary>
		/// Convert the <see cref="SegmentBuilder"/> object to an immutable <see cref="Segment"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Segment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface SegmentObject : NamedElement, RouteObject
	{
		SegmentPosition Position { get; }
	
	
		/// <summary>
		/// Convert the <see cref="SegmentObject"/> object to a builder <see cref="SegmentObjectBuilder"/> object.
		/// </summary>
		new SegmentObjectBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="SegmentObject"/> object to a builder <see cref="SegmentObjectBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new SegmentObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface SegmentObjectBuilder : NamedElementBuilder, RouteObjectBuilder
	{
		SegmentPositionBuilder Position { get; set; }
		void SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy);
		void SetPositionLazy(global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> lazy);
		void SetPositionLazy(global::System.Func<SegmentObject, SegmentPosition> immutableLazy, global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="SegmentObjectBuilder"/> object to an immutable <see cref="SegmentObject"/> object.
		/// </summary>
		new SegmentObject ToImmutable();
		/// <summary>
		/// Convert the <see cref="SegmentObjectBuilder"/> object to an immutable <see cref="SegmentObject"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new SegmentObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Derailer : SegmentObject
	{
		bool Active { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Derailer"/> object to a builder <see cref="DerailerBuilder"/> object.
		/// </summary>
		new DerailerBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Derailer"/> object to a builder <see cref="DerailerBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new DerailerBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DerailerBuilder : SegmentObjectBuilder
	{
		bool Active { get; set; }
		void SetActiveLazy(global::System.Func<bool> lazy);
		void SetActiveLazy(global::System.Func<DerailerBuilder, bool> lazy);
		void SetActiveLazy(global::System.Func<Derailer, bool> immutableLazy, global::System.Func<DerailerBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="DerailerBuilder"/> object to an immutable <see cref="Derailer"/> object.
		/// </summary>
		new Derailer ToImmutable();
		/// <summary>
		/// Convert the <see cref="DerailerBuilder"/> object to an immutable <see cref="Derailer"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Derailer ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LevelCrossing : SegmentObject
	{
		bool Closed { get; }
		double Length { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LevelCrossing"/> object to a builder <see cref="LevelCrossingBuilder"/> object.
		/// </summary>
		new LevelCrossingBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LevelCrossing"/> object to a builder <see cref="LevelCrossingBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LevelCrossingBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LevelCrossingBuilder : SegmentObjectBuilder
	{
		bool Closed { get; set; }
		void SetClosedLazy(global::System.Func<bool> lazy);
		void SetClosedLazy(global::System.Func<LevelCrossingBuilder, bool> lazy);
		void SetClosedLazy(global::System.Func<LevelCrossing, bool> immutableLazy, global::System.Func<LevelCrossingBuilder, bool> mutableLazy);
		double Length { get; set; }
		void SetLengthLazy(global::System.Func<double> lazy);
		void SetLengthLazy(global::System.Func<LevelCrossingBuilder, double> lazy);
		void SetLengthLazy(global::System.Func<LevelCrossing, double> immutableLazy, global::System.Func<LevelCrossingBuilder, double> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LevelCrossingBuilder"/> object to an immutable <see cref="LevelCrossing"/> object.
		/// </summary>
		new LevelCrossing ToImmutable();
		/// <summary>
		/// Convert the <see cref="LevelCrossingBuilder"/> object to an immutable <see cref="LevelCrossing"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LevelCrossing ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Signal : SegmentObject
	{
		Signal DistantFor { get; }
		bool Main { get; }
		bool Shunting { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Signal"/> object to a builder <see cref="SignalBuilder"/> object.
		/// </summary>
		new SignalBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Signal"/> object to a builder <see cref="SignalBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new SignalBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface SignalBuilder : SegmentObjectBuilder
	{
		SignalBuilder DistantFor { get; set; }
		void SetDistantForLazy(global::System.Func<SignalBuilder> lazy);
		void SetDistantForLazy(global::System.Func<SignalBuilder, SignalBuilder> lazy);
		void SetDistantForLazy(global::System.Func<Signal, Signal> immutableLazy, global::System.Func<SignalBuilder, SignalBuilder> mutableLazy);
		bool Main { get; set; }
		void SetMainLazy(global::System.Func<bool> lazy);
		void SetMainLazy(global::System.Func<SignalBuilder, bool> lazy);
		void SetMainLazy(global::System.Func<Signal, bool> immutableLazy, global::System.Func<SignalBuilder, bool> mutableLazy);
		bool Shunting { get; set; }
		void SetShuntingLazy(global::System.Func<bool> lazy);
		void SetShuntingLazy(global::System.Func<SignalBuilder, bool> lazy);
		void SetShuntingLazy(global::System.Func<Signal, bool> immutableLazy, global::System.Func<SignalBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="SignalBuilder"/> object to an immutable <see cref="Signal"/> object.
		/// </summary>
		new Signal ToImmutable();
		/// <summary>
		/// Convert the <see cref="SignalBuilder"/> object to an immutable <see cref="Signal"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Signal ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Platform : SegmentObject
	{
		double Length { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Platform"/> object to a builder <see cref="PlatformBuilder"/> object.
		/// </summary>
		new PlatformBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Platform"/> object to a builder <see cref="PlatformBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new PlatformBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface PlatformBuilder : SegmentObjectBuilder
	{
		double Length { get; set; }
		void SetLengthLazy(global::System.Func<double> lazy);
		void SetLengthLazy(global::System.Func<PlatformBuilder, double> lazy);
		void SetLengthLazy(global::System.Func<Platform, double> immutableLazy, global::System.Func<PlatformBuilder, double> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="PlatformBuilder"/> object to an immutable <see cref="Platform"/> object.
		/// </summary>
		new Platform ToImmutable();
		/// <summary>
		/// Convert the <see cref="PlatformBuilder"/> object to an immutable <see cref="Platform"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Platform ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface SegmentPosition : global::MetaDslx.Modeling.ImmutableObject
	{
		bool AtStart { get; }
		bool AtEnd { get; }
		double Position { get; }
		Side Side { get; }
		Orientation Orientation { get; }
		Segment Segment { get; }
	
	
		/// <summary>
		/// Convert the <see cref="SegmentPosition"/> object to a builder <see cref="SegmentPositionBuilder"/> object.
		/// </summary>
		new SegmentPositionBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="SegmentPosition"/> object to a builder <see cref="SegmentPositionBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new SegmentPositionBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface SegmentPositionBuilder : global::MetaDslx.Modeling.MutableObject
	{
		bool AtStart { get; set; }
		void SetAtStartLazy(global::System.Func<bool> lazy);
		void SetAtStartLazy(global::System.Func<SegmentPositionBuilder, bool> lazy);
		void SetAtStartLazy(global::System.Func<SegmentPosition, bool> immutableLazy, global::System.Func<SegmentPositionBuilder, bool> mutableLazy);
		bool AtEnd { get; set; }
		void SetAtEndLazy(global::System.Func<bool> lazy);
		void SetAtEndLazy(global::System.Func<SegmentPositionBuilder, bool> lazy);
		void SetAtEndLazy(global::System.Func<SegmentPosition, bool> immutableLazy, global::System.Func<SegmentPositionBuilder, bool> mutableLazy);
		double Position { get; set; }
		void SetPositionLazy(global::System.Func<double> lazy);
		void SetPositionLazy(global::System.Func<SegmentPositionBuilder, double> lazy);
		void SetPositionLazy(global::System.Func<SegmentPosition, double> immutableLazy, global::System.Func<SegmentPositionBuilder, double> mutableLazy);
		Side Side { get; set; }
		void SetSideLazy(global::System.Func<Side> lazy);
		void SetSideLazy(global::System.Func<SegmentPositionBuilder, Side> lazy);
		void SetSideLazy(global::System.Func<SegmentPosition, Side> immutableLazy, global::System.Func<SegmentPositionBuilder, Side> mutableLazy);
		Orientation Orientation { get; set; }
		void SetOrientationLazy(global::System.Func<Orientation> lazy);
		void SetOrientationLazy(global::System.Func<SegmentPositionBuilder, Orientation> lazy);
		void SetOrientationLazy(global::System.Func<SegmentPosition, Orientation> immutableLazy, global::System.Func<SegmentPositionBuilder, Orientation> mutableLazy);
		SegmentBuilder Segment { get; set; }
		void SetSegmentLazy(global::System.Func<SegmentBuilder> lazy);
		void SetSegmentLazy(global::System.Func<SegmentPositionBuilder, SegmentBuilder> lazy);
		void SetSegmentLazy(global::System.Func<SegmentPosition, Segment> immutableLazy, global::System.Func<SegmentPositionBuilder, SegmentBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="SegmentPositionBuilder"/> object to an immutable <see cref="SegmentPosition"/> object.
		/// </summary>
		new SegmentPosition ToImmutable();
		/// <summary>
		/// Convert the <see cref="SegmentPositionBuilder"/> object to an immutable <see cref="SegmentPosition"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new SegmentPosition ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Point : TrackObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<Vertex> Inputs { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Vertex> Outputs { get; }
		PointKind Kind { get; }
		int SelectedInput { get; }
		int SelectedOutput { get; }
		bool Locked { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Point"/> object to a builder <see cref="PointBuilder"/> object.
		/// </summary>
		new PointBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Point"/> object to a builder <see cref="PointBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new PointBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface PointBuilder : TrackObjectBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<VertexBuilder> Inputs { get; }
		global::MetaDslx.Modeling.MutableModelList<VertexBuilder> Outputs { get; }
		PointKind Kind { get; set; }
		void SetKindLazy(global::System.Func<PointKind> lazy);
		void SetKindLazy(global::System.Func<PointBuilder, PointKind> lazy);
		void SetKindLazy(global::System.Func<Point, PointKind> immutableLazy, global::System.Func<PointBuilder, PointKind> mutableLazy);
		int SelectedInput { get; set; }
		void SetSelectedInputLazy(global::System.Func<int> lazy);
		void SetSelectedInputLazy(global::System.Func<PointBuilder, int> lazy);
		void SetSelectedInputLazy(global::System.Func<Point, int> immutableLazy, global::System.Func<PointBuilder, int> mutableLazy);
		int SelectedOutput { get; set; }
		void SetSelectedOutputLazy(global::System.Func<int> lazy);
		void SetSelectedOutputLazy(global::System.Func<PointBuilder, int> lazy);
		void SetSelectedOutputLazy(global::System.Func<Point, int> immutableLazy, global::System.Func<PointBuilder, int> mutableLazy);
		bool Locked { get; set; }
		void SetLockedLazy(global::System.Func<bool> lazy);
		void SetLockedLazy(global::System.Func<PointBuilder, bool> lazy);
		void SetLockedLazy(global::System.Func<Point, bool> immutableLazy, global::System.Func<PointBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="PointBuilder"/> object to an immutable <see cref="Point"/> object.
		/// </summary>
		new Point ToImmutable();
		/// <summary>
		/// Convert the <see cref="PointBuilder"/> object to an immutable <see cref="Point"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Point ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Track : Declaration
	{
		global::MetaDslx.Modeling.ImmutableModelList<TrackObject> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Track"/> object to a builder <see cref="TrackBuilder"/> object.
		/// </summary>
		new TrackBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Track"/> object to a builder <see cref="TrackBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrackBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrackBuilder : DeclarationBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<TrackObjectBuilder> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrackBuilder"/> object to an immutable <see cref="Track"/> object.
		/// </summary>
		new Track ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrackBuilder"/> object to an immutable <see cref="Track"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Track ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface NamedElement : global::MetaDslx.Modeling.ImmutableObject
	{
		string Name { get; }
	
	
		/// <summary>
		/// Convert the <see cref="NamedElement"/> object to a builder <see cref="NamedElementBuilder"/> object.
		/// </summary>
		new NamedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="NamedElement"/> object to a builder <see cref="NamedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new NamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NamedElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
		string Name { get; set; }
		void SetNameLazy(global::System.Func<string> lazy);
		void SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy);
		void SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="NamedElementBuilder"/> object to an immutable <see cref="NamedElement"/> object.
		/// </summary>
		new NamedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="NamedElementBuilder"/> object to an immutable <see cref="NamedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new NamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Train : Declaration
	{
		double Length { get; }
		double Speed { get; }
		global::MetaDslx.Modeling.ImmutableModelList<TrainSegment> Segments { get; }
		SegmentPosition Position { get; }
		double Acceleration { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Train"/> object to a builder <see cref="TrainBuilder"/> object.
		/// </summary>
		new TrainBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Train"/> object to a builder <see cref="TrainBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrainBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrainBuilder : DeclarationBuilder
	{
		double Length { get; set; }
		void SetLengthLazy(global::System.Func<double> lazy);
		void SetLengthLazy(global::System.Func<TrainBuilder, double> lazy);
		void SetLengthLazy(global::System.Func<Train, double> immutableLazy, global::System.Func<TrainBuilder, double> mutableLazy);
		double Speed { get; set; }
		void SetSpeedLazy(global::System.Func<double> lazy);
		void SetSpeedLazy(global::System.Func<TrainBuilder, double> lazy);
		void SetSpeedLazy(global::System.Func<Train, double> immutableLazy, global::System.Func<TrainBuilder, double> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<TrainSegmentBuilder> Segments { get; }
		SegmentPositionBuilder Position { get; set; }
		void SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy);
		void SetPositionLazy(global::System.Func<TrainBuilder, SegmentPositionBuilder> lazy);
		void SetPositionLazy(global::System.Func<Train, SegmentPosition> immutableLazy, global::System.Func<TrainBuilder, SegmentPositionBuilder> mutableLazy);
		double Acceleration { get; set; }
		void SetAccelerationLazy(global::System.Func<double> lazy);
		void SetAccelerationLazy(global::System.Func<TrainBuilder, double> lazy);
		void SetAccelerationLazy(global::System.Func<Train, double> immutableLazy, global::System.Func<TrainBuilder, double> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrainBuilder"/> object to an immutable <see cref="Train"/> object.
		/// </summary>
		new Train ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrainBuilder"/> object to an immutable <see cref="Train"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Train ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TrainSegment : global::MetaDslx.Modeling.ImmutableObject
	{
		SegmentPosition Position { get; }
		double Length { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrainSegment"/> object to a builder <see cref="TrainSegmentBuilder"/> object.
		/// </summary>
		new TrainSegmentBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="TrainSegment"/> object to a builder <see cref="TrainSegmentBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrainSegmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrainSegmentBuilder : global::MetaDslx.Modeling.MutableObject
	{
		SegmentPositionBuilder Position { get; set; }
		void SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy);
		void SetPositionLazy(global::System.Func<TrainSegmentBuilder, SegmentPositionBuilder> lazy);
		void SetPositionLazy(global::System.Func<TrainSegment, SegmentPosition> immutableLazy, global::System.Func<TrainSegmentBuilder, SegmentPositionBuilder> mutableLazy);
		double Length { get; set; }
		void SetLengthLazy(global::System.Func<double> lazy);
		void SetLengthLazy(global::System.Func<TrainSegmentBuilder, double> lazy);
		void SetLengthLazy(global::System.Func<TrainSegment, double> immutableLazy, global::System.Func<TrainSegmentBuilder, double> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrainSegmentBuilder"/> object to an immutable <see cref="TrainSegment"/> object.
		/// </summary>
		new TrainSegment ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrainSegmentBuilder"/> object to an immutable <see cref="TrainSegment"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new TrainSegment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RouteObject : global::MetaDslx.Modeling.ImmutableObject
	{
		SpeedLimit SpeedLimit { get; }
		bool Error { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RouteObject"/> object to a builder <see cref="RouteObjectBuilder"/> object.
		/// </summary>
		new RouteObjectBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="RouteObject"/> object to a builder <see cref="RouteObjectBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RouteObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RouteObjectBuilder : global::MetaDslx.Modeling.MutableObject
	{
		SpeedLimit SpeedLimit { get; set; }
		void SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy);
		void SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy);
		void SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy);
		bool Error { get; set; }
		void SetErrorLazy(global::System.Func<bool> lazy);
		void SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy);
		void SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="RouteObjectBuilder"/> object to an immutable <see cref="RouteObject"/> object.
		/// </summary>
		new RouteObject ToImmutable();
		/// <summary>
		/// Convert the <see cref="RouteObjectBuilder"/> object to an immutable <see cref="RouteObject"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new RouteObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TrainRoute : Declaration
	{
		global::MetaDslx.Modeling.ImmutableModelList<TrainRouteObject> Path { get; }
		TrainRouteKind Kind { get; }
		Signal StartSignal { get; }
		Signal EndSignal { get; }
		global::MetaDslx.Modeling.ImmutableModelList<TrainRouteObject> ProtectionObjects { get; }
		global::MetaDslx.Modeling.ImmutableModelList<TrainRoute> ConflictingRoutes { get; }
		bool Locked { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrainRoute"/> object to a builder <see cref="TrainRouteBuilder"/> object.
		/// </summary>
		new TrainRouteBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="TrainRoute"/> object to a builder <see cref="TrainRouteBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrainRouteBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrainRouteBuilder : DeclarationBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<TrainRouteObjectBuilder> Path { get; }
		TrainRouteKind Kind { get; set; }
		void SetKindLazy(global::System.Func<TrainRouteKind> lazy);
		void SetKindLazy(global::System.Func<TrainRouteBuilder, TrainRouteKind> lazy);
		void SetKindLazy(global::System.Func<TrainRoute, TrainRouteKind> immutableLazy, global::System.Func<TrainRouteBuilder, TrainRouteKind> mutableLazy);
		SignalBuilder StartSignal { get; set; }
		void SetStartSignalLazy(global::System.Func<SignalBuilder> lazy);
		void SetStartSignalLazy(global::System.Func<TrainRouteBuilder, SignalBuilder> lazy);
		void SetStartSignalLazy(global::System.Func<TrainRoute, Signal> immutableLazy, global::System.Func<TrainRouteBuilder, SignalBuilder> mutableLazy);
		SignalBuilder EndSignal { get; set; }
		void SetEndSignalLazy(global::System.Func<SignalBuilder> lazy);
		void SetEndSignalLazy(global::System.Func<TrainRouteBuilder, SignalBuilder> lazy);
		void SetEndSignalLazy(global::System.Func<TrainRoute, Signal> immutableLazy, global::System.Func<TrainRouteBuilder, SignalBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<TrainRouteObjectBuilder> ProtectionObjects { get; }
		global::MetaDslx.Modeling.MutableModelList<TrainRouteBuilder> ConflictingRoutes { get; }
		bool Locked { get; set; }
		void SetLockedLazy(global::System.Func<bool> lazy);
		void SetLockedLazy(global::System.Func<TrainRouteBuilder, bool> lazy);
		void SetLockedLazy(global::System.Func<TrainRoute, bool> immutableLazy, global::System.Func<TrainRouteBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrainRouteBuilder"/> object to an immutable <see cref="TrainRoute"/> object.
		/// </summary>
		new TrainRoute ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrainRouteBuilder"/> object to an immutable <see cref="TrainRoute"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new TrainRoute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TrainRouteObject : global::MetaDslx.Modeling.ImmutableObject
	{
		SpeedLimit SpeedLimit { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrainRouteObject"/> object to a builder <see cref="TrainRouteObjectBuilder"/> object.
		/// </summary>
		new TrainRouteObjectBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="TrainRouteObject"/> object to a builder <see cref="TrainRouteObjectBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrainRouteObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrainRouteObjectBuilder : global::MetaDslx.Modeling.MutableObject
	{
		SpeedLimit SpeedLimit { get; set; }
		void SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy);
		void SetSpeedLimitLazy(global::System.Func<TrainRouteObjectBuilder, SpeedLimit> lazy);
		void SetSpeedLimitLazy(global::System.Func<TrainRouteObject, SpeedLimit> immutableLazy, global::System.Func<TrainRouteObjectBuilder, SpeedLimit> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrainRouteObjectBuilder"/> object to an immutable <see cref="TrainRouteObject"/> object.
		/// </summary>
		new TrainRouteObject ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrainRouteObjectBuilder"/> object to an immutable <see cref="TrainRouteObject"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new TrainRouteObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TrainRoutePoint : TrainRouteObject
	{
		Point OriginalPoint { get; }
		int SelectedInput { get; }
		int SelectedOutput { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrainRoutePoint"/> object to a builder <see cref="TrainRoutePointBuilder"/> object.
		/// </summary>
		new TrainRoutePointBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="TrainRoutePoint"/> object to a builder <see cref="TrainRoutePointBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrainRoutePointBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrainRoutePointBuilder : TrainRouteObjectBuilder
	{
		PointBuilder OriginalPoint { get; set; }
		void SetOriginalPointLazy(global::System.Func<PointBuilder> lazy);
		void SetOriginalPointLazy(global::System.Func<TrainRoutePointBuilder, PointBuilder> lazy);
		void SetOriginalPointLazy(global::System.Func<TrainRoutePoint, Point> immutableLazy, global::System.Func<TrainRoutePointBuilder, PointBuilder> mutableLazy);
		int SelectedInput { get; set; }
		void SetSelectedInputLazy(global::System.Func<int> lazy);
		void SetSelectedInputLazy(global::System.Func<TrainRoutePointBuilder, int> lazy);
		void SetSelectedInputLazy(global::System.Func<TrainRoutePoint, int> immutableLazy, global::System.Func<TrainRoutePointBuilder, int> mutableLazy);
		int SelectedOutput { get; set; }
		void SetSelectedOutputLazy(global::System.Func<int> lazy);
		void SetSelectedOutputLazy(global::System.Func<TrainRoutePointBuilder, int> lazy);
		void SetSelectedOutputLazy(global::System.Func<TrainRoutePoint, int> immutableLazy, global::System.Func<TrainRoutePointBuilder, int> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrainRoutePointBuilder"/> object to an immutable <see cref="TrainRoutePoint"/> object.
		/// </summary>
		new TrainRoutePoint ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrainRoutePointBuilder"/> object to an immutable <see cref="TrainRoutePoint"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new TrainRoutePoint ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TrainRouteSegment : TrainRouteObject
	{
		Segment OriginalSegment { get; }
	
	
		/// <summary>
		/// Convert the <see cref="TrainRouteSegment"/> object to a builder <see cref="TrainRouteSegmentBuilder"/> object.
		/// </summary>
		new TrainRouteSegmentBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="TrainRouteSegment"/> object to a builder <see cref="TrainRouteSegmentBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new TrainRouteSegmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TrainRouteSegmentBuilder : TrainRouteObjectBuilder
	{
		SegmentBuilder OriginalSegment { get; set; }
		void SetOriginalSegmentLazy(global::System.Func<SegmentBuilder> lazy);
		void SetOriginalSegmentLazy(global::System.Func<TrainRouteSegmentBuilder, SegmentBuilder> lazy);
		void SetOriginalSegmentLazy(global::System.Func<TrainRouteSegment, Segment> immutableLazy, global::System.Func<TrainRouteSegmentBuilder, SegmentBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="TrainRouteSegmentBuilder"/> object to an immutable <see cref="TrainRouteSegment"/> object.
		/// </summary>
		new TrainRouteSegment ToImmutable();
		/// <summary>
		/// Convert the <see cref="TrainRouteSegmentBuilder"/> object to an immutable <see cref="TrainRouteSegment"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new TrainRouteSegment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class RailDslDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static RailDslDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			Station.Initialize();
			Declaration.Initialize();
			TrackObject.Initialize();
			Vertex.Initialize();
			Segment.Initialize();
			SegmentObject.Initialize();
			Derailer.Initialize();
			LevelCrossing.Initialize();
			Signal.Initialize();
			Platform.Initialize();
			SegmentPosition.Initialize();
			Point.Initialize();
			Track.Initialize();
			NamedElement.Initialize();
			Train.Initialize();
			TrainSegment.Initialize();
			RouteObject.Initialize();
			TrainRoute.Initialize();
			TrainRouteObject.Initialize();
			TrainRoutePoint.Initialize();
			TrainRouteSegment.Initialize();
			properties.Add(RailDslDescriptor.Station.DeclarationsProperty);
			properties.Add(RailDslDescriptor.TrackObject.LengthProperty);
			properties.Add(RailDslDescriptor.Vertex.KindProperty);
			properties.Add(RailDslDescriptor.Segment.StartProperty);
			properties.Add(RailDslDescriptor.Segment.EndProperty);
			properties.Add(RailDslDescriptor.Segment.ObjectsProperty);
			properties.Add(RailDslDescriptor.SegmentObject.PositionProperty);
			properties.Add(RailDslDescriptor.Derailer.ActiveProperty);
			properties.Add(RailDslDescriptor.LevelCrossing.ClosedProperty);
			properties.Add(RailDslDescriptor.LevelCrossing.LengthProperty);
			properties.Add(RailDslDescriptor.Signal.DistantForProperty);
			properties.Add(RailDslDescriptor.Signal.MainProperty);
			properties.Add(RailDslDescriptor.Signal.ShuntingProperty);
			properties.Add(RailDslDescriptor.Platform.LengthProperty);
			properties.Add(RailDslDescriptor.SegmentPosition.AtStartProperty);
			properties.Add(RailDslDescriptor.SegmentPosition.AtEndProperty);
			properties.Add(RailDslDescriptor.SegmentPosition.PositionProperty);
			properties.Add(RailDslDescriptor.SegmentPosition.SideProperty);
			properties.Add(RailDslDescriptor.SegmentPosition.OrientationProperty);
			properties.Add(RailDslDescriptor.SegmentPosition.SegmentProperty);
			properties.Add(RailDslDescriptor.Point.InputsProperty);
			properties.Add(RailDslDescriptor.Point.OutputsProperty);
			properties.Add(RailDslDescriptor.Point.KindProperty);
			properties.Add(RailDslDescriptor.Point.SelectedInputProperty);
			properties.Add(RailDslDescriptor.Point.SelectedOutputProperty);
			properties.Add(RailDslDescriptor.Point.LockedProperty);
			properties.Add(RailDslDescriptor.Track.ElementsProperty);
			properties.Add(RailDslDescriptor.NamedElement.NameProperty);
			properties.Add(RailDslDescriptor.Train.LengthProperty);
			properties.Add(RailDslDescriptor.Train.SpeedProperty);
			properties.Add(RailDslDescriptor.Train.SegmentsProperty);
			properties.Add(RailDslDescriptor.Train.PositionProperty);
			properties.Add(RailDslDescriptor.Train.AccelerationProperty);
			properties.Add(RailDslDescriptor.TrainSegment.PositionProperty);
			properties.Add(RailDslDescriptor.TrainSegment.LengthProperty);
			properties.Add(RailDslDescriptor.RouteObject.SpeedLimitProperty);
			properties.Add(RailDslDescriptor.RouteObject.ErrorProperty);
			properties.Add(RailDslDescriptor.TrainRoute.PathProperty);
			properties.Add(RailDslDescriptor.TrainRoute.KindProperty);
			properties.Add(RailDslDescriptor.TrainRoute.StartSignalProperty);
			properties.Add(RailDslDescriptor.TrainRoute.EndSignalProperty);
			properties.Add(RailDslDescriptor.TrainRoute.ProtectionObjectsProperty);
			properties.Add(RailDslDescriptor.TrainRoute.ConflictingRoutesProperty);
			properties.Add(RailDslDescriptor.TrainRoute.LockedProperty);
			properties.Add(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty);
			properties.Add(RailDslDescriptor.TrainRoutePoint.OriginalPointProperty);
			properties.Add(RailDslDescriptor.TrainRoutePoint.SelectedInputProperty);
			properties.Add(RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty);
			properties.Add(RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://www.bme.hu/iit/vke/raildsl";
		public const string MPrefix = "railDsl";
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.StationId), typeof(global::RailDsl.Station), typeof(global::RailDsl.StationBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.NamedElement) })]
		public static class Station
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Station()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Station));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Station; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Station), name: "Declarations",
			        immutableType: typeof(global::RailDsl.Declaration),
			        mutableType: typeof(global::RailDsl.DeclarationBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Station_Declarations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.DeclarationId), typeof(global::RailDsl.Declaration), typeof(global::RailDsl.DeclarationBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.NamedElement) })]
		public static class Declaration
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Declaration()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Declaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Declaration; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrackObjectId), typeof(global::RailDsl.TrackObject), typeof(global::RailDsl.TrackObjectBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.Declaration), typeof(RailDslDescriptor.RouteObject) })]
		public static class TrackObject
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static TrackObject()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(TrackObject));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.TrackObject; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LengthProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrackObject), name: "Length",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.TrackObject_Length,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.VertexId), typeof(global::RailDsl.Vertex), typeof(global::RailDsl.VertexBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.Declaration) })]
		public static class Vertex
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Vertex()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Vertex));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Vertex; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Vertex), name: "Kind",
			        immutableType: typeof(global::RailDsl.VertexKind),
			        mutableType: typeof(global::RailDsl.VertexKind),
					metaProperty: () => global::RailDsl.RailDslInstance.Vertex_Kind,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.SegmentId), typeof(global::RailDsl.Segment), typeof(global::RailDsl.SegmentBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.TrackObject) })]
		public static class Segment
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Segment()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Segment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Segment; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty StartProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Segment), name: "Start",
			        immutableType: typeof(global::RailDsl.Vertex),
			        mutableType: typeof(global::RailDsl.VertexBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Segment_Start,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EndProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Segment), name: "End",
			        immutableType: typeof(global::RailDsl.Vertex),
			        mutableType: typeof(global::RailDsl.VertexBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Segment_End,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ObjectsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Segment), name: "Objects",
			        immutableType: typeof(global::RailDsl.SegmentObject),
			        mutableType: typeof(global::RailDsl.SegmentObjectBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Segment_Objects,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.SegmentObjectId), typeof(global::RailDsl.SegmentObject), typeof(global::RailDsl.SegmentObjectBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.NamedElement), typeof(RailDslDescriptor.RouteObject) })]
		public static class SegmentObject
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static SegmentObject()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(SegmentObject));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.SegmentObject; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty PositionProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentObject), name: "Position",
			        immutableType: typeof(global::RailDsl.SegmentPosition),
			        mutableType: typeof(global::RailDsl.SegmentPositionBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentObject_Position,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.DerailerId), typeof(global::RailDsl.Derailer), typeof(global::RailDsl.DerailerBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.SegmentObject) })]
		public static class Derailer
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Derailer()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Derailer));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Derailer; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ActiveProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Derailer), name: "Active",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.Derailer_Active,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.LevelCrossingId), typeof(global::RailDsl.LevelCrossing), typeof(global::RailDsl.LevelCrossingBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.SegmentObject) })]
		public static class LevelCrossing
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LevelCrossing()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LevelCrossing));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.LevelCrossing; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ClosedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LevelCrossing), name: "Closed",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.LevelCrossing_Closed,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LengthProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LevelCrossing), name: "Length",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.LevelCrossing_Length,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.SignalId), typeof(global::RailDsl.Signal), typeof(global::RailDsl.SignalBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.SegmentObject) })]
		public static class Signal
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Signal()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Signal));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Signal; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DistantForProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Signal), name: "DistantFor",
			        immutableType: typeof(global::RailDsl.Signal),
			        mutableType: typeof(global::RailDsl.SignalBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Signal_DistantFor,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty MainProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Signal), name: "Main",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.Signal_Main,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ShuntingProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Signal), name: "Shunting",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.Signal_Shunting,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.PlatformId), typeof(global::RailDsl.Platform), typeof(global::RailDsl.PlatformBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.SegmentObject) })]
		public static class Platform
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Platform()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Platform));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Platform; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LengthProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Platform), name: "Length",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.Platform_Length,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.SegmentPositionId), typeof(global::RailDsl.SegmentPosition), typeof(global::RailDsl.SegmentPositionBuilder))]
		public static class SegmentPosition
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static SegmentPosition()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(SegmentPosition));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.SegmentPosition; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AtStartProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentPosition), name: "AtStart",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentPosition_AtStart,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AtEndProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentPosition), name: "AtEnd",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentPosition_AtEnd,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PositionProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentPosition), name: "Position",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentPosition_Position,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SideProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentPosition), name: "Side",
			        immutableType: typeof(global::RailDsl.Side),
			        mutableType: typeof(global::RailDsl.Side),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentPosition_Side,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty OrientationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentPosition), name: "Orientation",
			        immutableType: typeof(global::RailDsl.Orientation),
			        mutableType: typeof(global::RailDsl.Orientation),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentPosition_Orientation,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SegmentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(SegmentPosition), name: "Segment",
			        immutableType: typeof(global::RailDsl.Segment),
			        mutableType: typeof(global::RailDsl.SegmentBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.SegmentPosition_Segment,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.PointId), typeof(global::RailDsl.Point), typeof(global::RailDsl.PointBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.TrackObject) })]
		public static class Point
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Point()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Point));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Point; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty InputsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Point), name: "Inputs",
			        immutableType: typeof(global::RailDsl.Vertex),
			        mutableType: typeof(global::RailDsl.VertexBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Point_Inputs,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty OutputsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Point), name: "Outputs",
			        immutableType: typeof(global::RailDsl.Vertex),
			        mutableType: typeof(global::RailDsl.VertexBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Point_Outputs,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Point), name: "Kind",
			        immutableType: typeof(global::RailDsl.PointKind),
			        mutableType: typeof(global::RailDsl.PointKind),
					metaProperty: () => global::RailDsl.RailDslInstance.Point_Kind,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SelectedInputProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Point), name: "SelectedInput",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::RailDsl.RailDslInstance.Point_SelectedInput,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SelectedOutputProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Point), name: "SelectedOutput",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::RailDsl.RailDslInstance.Point_SelectedOutput,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LockedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Point), name: "Locked",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.Point_Locked,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrackId), typeof(global::RailDsl.Track), typeof(global::RailDsl.TrackBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.Declaration) })]
		public static class Track
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Track()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Track));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Track; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.NonUniqueAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Track), name: "Elements",
			        immutableType: typeof(global::RailDsl.TrackObject),
			        mutableType: typeof(global::RailDsl.TrackObjectBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Track_Elements,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.NamedElementId), typeof(global::RailDsl.NamedElement), typeof(global::RailDsl.NamedElementBuilder))]
		public static class NamedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static NamedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(NamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.NamedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(NamedElement), name: "Name",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::RailDsl.RailDslInstance.NamedElement_Name,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrainId), typeof(global::RailDsl.Train), typeof(global::RailDsl.TrainBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.Declaration) })]
		public static class Train
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Train()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Train));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.Train; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LengthProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Train), name: "Length",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.Train_Length,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SpeedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Train), name: "Speed",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.Train_Speed,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty SegmentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Train), name: "Segments",
			        immutableType: typeof(global::RailDsl.TrainSegment),
			        mutableType: typeof(global::RailDsl.TrainSegmentBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Train_Segments,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PositionProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Train), name: "Position",
			        immutableType: typeof(global::RailDsl.SegmentPosition),
			        mutableType: typeof(global::RailDsl.SegmentPositionBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.Train_Position,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AccelerationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Train), name: "Acceleration",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.Train_Acceleration,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrainSegmentId), typeof(global::RailDsl.TrainSegment), typeof(global::RailDsl.TrainSegmentBuilder))]
		public static class TrainSegment
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static TrainSegment()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(TrainSegment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.TrainSegment; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PositionProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainSegment), name: "Position",
			        immutableType: typeof(global::RailDsl.SegmentPosition),
			        mutableType: typeof(global::RailDsl.SegmentPositionBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainSegment_Position,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LengthProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainSegment), name: "Length",
			        immutableType: typeof(double),
			        mutableType: typeof(double),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainSegment_Length,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.RouteObjectId), typeof(global::RailDsl.RouteObject), typeof(global::RailDsl.RouteObjectBuilder))]
		public static class RouteObject
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static RouteObject()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(RouteObject));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.RouteObject; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SpeedLimitProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RouteObject), name: "SpeedLimit",
			        immutableType: typeof(global::RailDsl.SpeedLimit),
			        mutableType: typeof(global::RailDsl.SpeedLimit),
					metaProperty: () => global::RailDsl.RailDslInstance.RouteObject_SpeedLimit,
					defaultValue: SpeedLimit.Max);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ErrorProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RouteObject), name: "Error",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.RouteObject_Error,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrainRouteId), typeof(global::RailDsl.TrainRoute), typeof(global::RailDsl.TrainRouteBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.Declaration) })]
		public static class TrainRoute
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static TrainRoute()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(TrainRoute));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.TrainRoute; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty PathProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "Path",
			        immutableType: typeof(global::RailDsl.TrainRouteObject),
			        mutableType: typeof(global::RailDsl.TrainRouteObjectBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_Path,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "Kind",
			        immutableType: typeof(global::RailDsl.TrainRouteKind),
			        mutableType: typeof(global::RailDsl.TrainRouteKind),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_Kind,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty StartSignalProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "StartSignal",
			        immutableType: typeof(global::RailDsl.Signal),
			        mutableType: typeof(global::RailDsl.SignalBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_StartSignal,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EndSignalProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "EndSignal",
			        immutableType: typeof(global::RailDsl.Signal),
			        mutableType: typeof(global::RailDsl.SignalBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_EndSignal,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ProtectionObjectsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "ProtectionObjects",
			        immutableType: typeof(global::RailDsl.TrainRouteObject),
			        mutableType: typeof(global::RailDsl.TrainRouteObjectBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_ProtectionObjects,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ConflictingRoutesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "ConflictingRoutes",
			        immutableType: typeof(global::RailDsl.TrainRoute),
			        mutableType: typeof(global::RailDsl.TrainRouteBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_ConflictingRoutes,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LockedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoute), name: "Locked",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoute_Locked,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrainRouteObjectId), typeof(global::RailDsl.TrainRouteObject), typeof(global::RailDsl.TrainRouteObjectBuilder))]
		public static class TrainRouteObject
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static TrainRouteObject()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(TrainRouteObject));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.TrainRouteObject; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SpeedLimitProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRouteObject), name: "SpeedLimit",
			        immutableType: typeof(global::RailDsl.SpeedLimit),
			        mutableType: typeof(global::RailDsl.SpeedLimit),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRouteObject_SpeedLimit,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrainRoutePointId), typeof(global::RailDsl.TrainRoutePoint), typeof(global::RailDsl.TrainRoutePointBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.TrainRouteObject) })]
		public static class TrainRoutePoint
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static TrainRoutePoint()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(TrainRoutePoint));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.TrainRoutePoint; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty OriginalPointProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoutePoint), name: "OriginalPoint",
			        immutableType: typeof(global::RailDsl.Point),
			        mutableType: typeof(global::RailDsl.PointBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoutePoint_OriginalPoint,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SelectedInputProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoutePoint), name: "SelectedInput",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoutePoint_SelectedInput,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SelectedOutputProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRoutePoint), name: "SelectedOutput",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRoutePoint_SelectedOutput,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::RailDsl.Internal.TrainRouteSegmentId), typeof(global::RailDsl.TrainRouteSegment), typeof(global::RailDsl.TrainRouteSegmentBuilder), BaseDescriptors = new global::System.Type[] { typeof(RailDslDescriptor.TrainRouteObject) })]
		public static class TrainRouteSegment
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static TrainRouteSegment()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(TrainRouteSegment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::.MetaClass MMetaClass
			{
				get { return global::RailDsl.RailDslInstance.TrainRouteSegment; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty OriginalSegmentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(TrainRouteSegment), name: "OriginalSegment",
			        immutableType: typeof(global::RailDsl.Segment),
			        mutableType: typeof(global::RailDsl.SegmentBuilder),
					metaProperty: () => global::RailDsl.RailDslInstance.TrainRouteSegment_OriginalSegment,
					defaultValue: null);
		}
	}
}

namespace RailDsl.Internal
{
	
	internal class StationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Station.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new StationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new StationBuilderImpl(this, model, creating);
		}
	}
	
	internal class StationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Station
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Declaration> declarations0;
	
		internal StationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Station; }
		}
	
		public new StationBuilder ToMutable()
		{
			return (StationBuilder)base.ToMutable();
		}
	
		public new StationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (StationBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::RailDsl.RailDslDescriptor.Station.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class StationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, StationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> declarations0;
	
		internal StationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Station(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Station_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Station; }
		}
	
		public new Station ToImmutable()
		{
			return (Station)base.ToImmutable();
		}
	
		public new Station ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Station)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::RailDsl.RailDslDescriptor.Station.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class DeclarationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Declaration.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeclarationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Declaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal DeclarationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Declaration; }
		}
	
		public new DeclarationBuilder ToMutable()
		{
			return (DeclarationBuilder)base.ToMutable();
		}
	
		public new DeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DeclarationBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class DeclarationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, DeclarationBuilder
	{
	
		internal DeclarationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Declaration(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Declaration_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Declaration; }
		}
	
		public new Declaration ToImmutable()
		{
			return (Declaration)base.ToImmutable();
		}
	
		public new Declaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Declaration)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrackObjectId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.TrackObject.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrackObjectImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrackObjectBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrackObjectImpl : global::MetaDslx.Modeling.ImmutableObjectBase, TrackObject
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
	
		internal TrackObjectImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrackObject; }
		}
	
		public new TrackObjectBuilder ToMutable()
		{
			return (TrackObjectBuilder)base.ToMutable();
		}
	
		public new TrackObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrackObjectBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty, ref length0); }
		}
	}
	
	internal class TrackObjectBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrackObjectBuilder
	{
	
		internal TrackObjectBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.TrackObject(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.TrackObject_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrackObject; }
		}
	
		public new TrackObject ToImmutable()
		{
			return (TrackObject)base.ToImmutable();
		}
	
		public new TrackObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TrackObject)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty, value); }
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, lazy);
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<TrackObjectBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, lazy);
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<TrackObject, double> immutableLazy, global::System.Func<TrackObjectBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class VertexId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Vertex.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new VertexImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new VertexBuilderImpl(this, model, creating);
		}
	}
	
	internal class VertexImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Vertex
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private VertexKind kind0;
	
		internal VertexImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Vertex; }
		}
	
		public new VertexBuilder ToMutable()
		{
			return (VertexBuilder)base.ToMutable();
		}
	
		public new VertexBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (VertexBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public VertexKind Kind
		{
		    get { return this.GetValue<VertexKind>(global::RailDsl.RailDslDescriptor.Vertex.KindProperty, ref kind0); }
		}
	}
	
	internal class VertexBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, VertexBuilder
	{
	
		internal VertexBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Vertex(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Vertex_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Vertex; }
		}
	
		public new Vertex ToImmutable()
		{
			return (Vertex)base.ToImmutable();
		}
	
		public new Vertex ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Vertex)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public VertexKind Kind
		{
			get { return this.GetValue<VertexKind>(global::RailDsl.RailDslDescriptor.Vertex.KindProperty); }
			set { this.SetValue<VertexKind>(global::RailDsl.RailDslDescriptor.Vertex.KindProperty, value); }
		}
		
		void VertexBuilder.SetKindLazy(global::System.Func<VertexKind> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Vertex.KindProperty, lazy);
		}
		
		void VertexBuilder.SetKindLazy(global::System.Func<VertexBuilder, VertexKind> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Vertex.KindProperty, lazy);
		}
		
		void VertexBuilder.SetKindLazy(global::System.Func<Vertex, VertexKind> immutableLazy, global::System.Func<VertexBuilder, VertexKind> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Vertex.KindProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class SegmentId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Segment.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new SegmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new SegmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class SegmentImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Segment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vertex start0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vertex end0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<SegmentObject> objects0;
	
		internal SegmentImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Segment; }
		}
	
		public new SegmentBuilder ToMutable()
		{
			return (SegmentBuilder)base.ToMutable();
		}
	
		public new SegmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (SegmentBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TrackObjectBuilder TrackObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		TrackObjectBuilder TrackObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty, ref length0); }
		}
	
		
		public Vertex Start
		{
		    get { return this.GetReference<Vertex>(global::RailDsl.RailDslDescriptor.Segment.StartProperty, ref start0); }
		}
	
		
		public Vertex End
		{
		    get { return this.GetReference<Vertex>(global::RailDsl.RailDslDescriptor.Segment.EndProperty, ref end0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<SegmentObject> Objects
		{
		    get { return this.GetList<SegmentObject>(global::RailDsl.RailDslDescriptor.Segment.ObjectsProperty, ref objects0); }
		}
	}
	
	internal class SegmentBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, SegmentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<SegmentObjectBuilder> objects0;
	
		internal SegmentBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Segment(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Segment_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Segment; }
		}
	
		public new Segment ToImmutable()
		{
			return (Segment)base.ToImmutable();
		}
	
		public new Segment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Segment)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TrackObject TrackObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TrackObject TrackObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty, value); }
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, lazy);
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<TrackObjectBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, lazy);
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<TrackObject, double> immutableLazy, global::System.Func<TrackObjectBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, immutableLazy, mutableLazy);
		}
	
		
		public VertexBuilder Start
		{
			get { return this.GetReference<VertexBuilder>(global::RailDsl.RailDslDescriptor.Segment.StartProperty); }
			set { this.SetReference<VertexBuilder>(global::RailDsl.RailDslDescriptor.Segment.StartProperty, value); }
		}
		
		void SegmentBuilder.SetStartLazy(global::System.Func<VertexBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Segment.StartProperty, lazy);
		}
		
		void SegmentBuilder.SetStartLazy(global::System.Func<SegmentBuilder, VertexBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Segment.StartProperty, lazy);
		}
		
		void SegmentBuilder.SetStartLazy(global::System.Func<Segment, Vertex> immutableLazy, global::System.Func<SegmentBuilder, VertexBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.Segment.StartProperty, immutableLazy, mutableLazy);
		}
	
		
		public VertexBuilder End
		{
			get { return this.GetReference<VertexBuilder>(global::RailDsl.RailDslDescriptor.Segment.EndProperty); }
			set { this.SetReference<VertexBuilder>(global::RailDsl.RailDslDescriptor.Segment.EndProperty, value); }
		}
		
		void SegmentBuilder.SetEndLazy(global::System.Func<VertexBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Segment.EndProperty, lazy);
		}
		
		void SegmentBuilder.SetEndLazy(global::System.Func<SegmentBuilder, VertexBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Segment.EndProperty, lazy);
		}
		
		void SegmentBuilder.SetEndLazy(global::System.Func<Segment, Vertex> immutableLazy, global::System.Func<SegmentBuilder, VertexBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.Segment.EndProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<SegmentObjectBuilder> Objects
		{
			get { return this.GetList<SegmentObjectBuilder>(global::RailDsl.RailDslDescriptor.Segment.ObjectsProperty, ref objects0); }
		}
	}
	
	internal class SegmentObjectId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.SegmentObject.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new SegmentObjectImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new SegmentObjectBuilderImpl(this, model, creating);
		}
	}
	
	internal class SegmentObjectImpl : global::MetaDslx.Modeling.ImmutableObjectBase, SegmentObject
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
	
		internal SegmentObjectImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.SegmentObject; }
		}
	
		public new SegmentObjectBuilder ToMutable()
		{
			return (SegmentObjectBuilder)base.ToMutable();
		}
	
		public new SegmentObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (SegmentObjectBuilder)base.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, ref position0); }
		}
	}
	
	internal class SegmentObjectBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, SegmentObjectBuilder
	{
	
		internal SegmentObjectBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.SegmentObject(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.SegmentObject_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.SegmentObject; }
		}
	
		public new SegmentObject ToImmutable()
		{
			return (SegmentObject)base.ToImmutable();
		}
	
		public new SegmentObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (SegmentObject)base.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, value); }
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObject, SegmentPosition> immutableLazy, global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class DerailerId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Derailer.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DerailerImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DerailerBuilderImpl(this, model, creating);
		}
	}
	
	internal class DerailerImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Derailer
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool active0;
	
		internal DerailerImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Derailer; }
		}
	
		public new DerailerBuilder ToMutable()
		{
			return (DerailerBuilder)base.ToMutable();
		}
	
		public new DerailerBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DerailerBuilder)base.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, ref position0); }
		}
	
		
		public bool Active
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Derailer.ActiveProperty, ref active0); }
		}
	}
	
	internal class DerailerBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, DerailerBuilder
	{
	
		internal DerailerBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Derailer(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Derailer_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Derailer; }
		}
	
		public new Derailer ToImmutable()
		{
			return (Derailer)base.ToImmutable();
		}
	
		public new Derailer ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Derailer)base.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, value); }
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObject, SegmentPosition> immutableLazy, global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Active
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Derailer.ActiveProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.Derailer.ActiveProperty, value); }
		}
		
		void DerailerBuilder.SetActiveLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Derailer.ActiveProperty, lazy);
		}
		
		void DerailerBuilder.SetActiveLazy(global::System.Func<DerailerBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Derailer.ActiveProperty, lazy);
		}
		
		void DerailerBuilder.SetActiveLazy(global::System.Func<Derailer, bool> immutableLazy, global::System.Func<DerailerBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Derailer.ActiveProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class LevelCrossingId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.LevelCrossing.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LevelCrossingImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LevelCrossingBuilderImpl(this, model, creating);
		}
	}
	
	internal class LevelCrossingImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LevelCrossing
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool closed0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
	
		internal LevelCrossingImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.LevelCrossing; }
		}
	
		public new LevelCrossingBuilder ToMutable()
		{
			return (LevelCrossingBuilder)base.ToMutable();
		}
	
		public new LevelCrossingBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LevelCrossingBuilder)base.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, ref position0); }
		}
	
		
		public bool Closed
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.LevelCrossing.ClosedProperty, ref closed0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.LevelCrossing.LengthProperty, ref length0); }
		}
	}
	
	internal class LevelCrossingBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LevelCrossingBuilder
	{
	
		internal LevelCrossingBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.LevelCrossing(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.LevelCrossing_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.LevelCrossing; }
		}
	
		public new LevelCrossing ToImmutable()
		{
			return (LevelCrossing)base.ToImmutable();
		}
	
		public new LevelCrossing ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LevelCrossing)base.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, value); }
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObject, SegmentPosition> immutableLazy, global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Closed
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.LevelCrossing.ClosedProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.LevelCrossing.ClosedProperty, value); }
		}
		
		void LevelCrossingBuilder.SetClosedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.LevelCrossing.ClosedProperty, lazy);
		}
		
		void LevelCrossingBuilder.SetClosedLazy(global::System.Func<LevelCrossingBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.LevelCrossing.ClosedProperty, lazy);
		}
		
		void LevelCrossingBuilder.SetClosedLazy(global::System.Func<LevelCrossing, bool> immutableLazy, global::System.Func<LevelCrossingBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.LevelCrossing.ClosedProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.LevelCrossing.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.LevelCrossing.LengthProperty, value); }
		}
		
		void LevelCrossingBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.LevelCrossing.LengthProperty, lazy);
		}
		
		void LevelCrossingBuilder.SetLengthLazy(global::System.Func<LevelCrossingBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.LevelCrossing.LengthProperty, lazy);
		}
		
		void LevelCrossingBuilder.SetLengthLazy(global::System.Func<LevelCrossing, double> immutableLazy, global::System.Func<LevelCrossingBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.LevelCrossing.LengthProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class SignalId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Signal.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new SignalImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new SignalBuilderImpl(this, model, creating);
		}
	}
	
	internal class SignalImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Signal
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Signal distantFor0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool main0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool shunting0;
	
		internal SignalImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Signal; }
		}
	
		public new SignalBuilder ToMutable()
		{
			return (SignalBuilder)base.ToMutable();
		}
	
		public new SignalBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (SignalBuilder)base.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, ref position0); }
		}
	
		
		public Signal DistantFor
		{
		    get { return this.GetReference<Signal>(global::RailDsl.RailDslDescriptor.Signal.DistantForProperty, ref distantFor0); }
		}
	
		
		public bool Main
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Signal.MainProperty, ref main0); }
		}
	
		
		public bool Shunting
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Signal.ShuntingProperty, ref shunting0); }
		}
	}
	
	internal class SignalBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, SignalBuilder
	{
	
		internal SignalBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Signal(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Signal_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Signal; }
		}
	
		public new Signal ToImmutable()
		{
			return (Signal)base.ToImmutable();
		}
	
		public new Signal ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Signal)base.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, value); }
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObject, SegmentPosition> immutableLazy, global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public SignalBuilder DistantFor
		{
			get { return this.GetReference<SignalBuilder>(global::RailDsl.RailDslDescriptor.Signal.DistantForProperty); }
			set { this.SetReference<SignalBuilder>(global::RailDsl.RailDslDescriptor.Signal.DistantForProperty, value); }
		}
		
		void SignalBuilder.SetDistantForLazy(global::System.Func<SignalBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Signal.DistantForProperty, lazy);
		}
		
		void SignalBuilder.SetDistantForLazy(global::System.Func<SignalBuilder, SignalBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Signal.DistantForProperty, lazy);
		}
		
		void SignalBuilder.SetDistantForLazy(global::System.Func<Signal, Signal> immutableLazy, global::System.Func<SignalBuilder, SignalBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.Signal.DistantForProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Main
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Signal.MainProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.Signal.MainProperty, value); }
		}
		
		void SignalBuilder.SetMainLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Signal.MainProperty, lazy);
		}
		
		void SignalBuilder.SetMainLazy(global::System.Func<SignalBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Signal.MainProperty, lazy);
		}
		
		void SignalBuilder.SetMainLazy(global::System.Func<Signal, bool> immutableLazy, global::System.Func<SignalBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Signal.MainProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Shunting
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Signal.ShuntingProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.Signal.ShuntingProperty, value); }
		}
		
		void SignalBuilder.SetShuntingLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Signal.ShuntingProperty, lazy);
		}
		
		void SignalBuilder.SetShuntingLazy(global::System.Func<SignalBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Signal.ShuntingProperty, lazy);
		}
		
		void SignalBuilder.SetShuntingLazy(global::System.Func<Signal, bool> immutableLazy, global::System.Func<SignalBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Signal.ShuntingProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class PlatformId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Platform.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new PlatformImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new PlatformBuilderImpl(this, model, creating);
		}
	}
	
	internal class PlatformImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Platform
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
	
		internal PlatformImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Platform; }
		}
	
		public new PlatformBuilder ToMutable()
		{
			return (PlatformBuilder)base.ToMutable();
		}
	
		public new PlatformBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (PlatformBuilder)base.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		SegmentObjectBuilder SegmentObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, ref position0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Platform.LengthProperty, ref length0); }
		}
	}
	
	internal class PlatformBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, PlatformBuilder
	{
	
		internal PlatformBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Platform(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Platform_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Platform; }
		}
	
		public new Platform ToImmutable()
		{
			return (Platform)base.ToImmutable();
		}
	
		public new Platform ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Platform)base.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SegmentObject SegmentObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.SegmentObject.PositionProperty, value); }
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, lazy);
		}
		
		void SegmentObjectBuilder.SetPositionLazy(global::System.Func<SegmentObject, SegmentPosition> immutableLazy, global::System.Func<SegmentObjectBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentObject.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Platform.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.Platform.LengthProperty, value); }
		}
		
		void PlatformBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Platform.LengthProperty, lazy);
		}
		
		void PlatformBuilder.SetLengthLazy(global::System.Func<PlatformBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Platform.LengthProperty, lazy);
		}
		
		void PlatformBuilder.SetLengthLazy(global::System.Func<Platform, double> immutableLazy, global::System.Func<PlatformBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Platform.LengthProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class SegmentPositionId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.SegmentPosition.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new SegmentPositionImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new SegmentPositionBuilderImpl(this, model, creating);
		}
	}
	
	internal class SegmentPositionImpl : global::MetaDslx.Modeling.ImmutableObjectBase, SegmentPosition
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool atStart0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool atEnd0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Side side0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Orientation orientation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Segment segment0;
	
		internal SegmentPositionImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.SegmentPosition; }
		}
	
		public new SegmentPositionBuilder ToMutable()
		{
			return (SegmentPositionBuilder)base.ToMutable();
		}
	
		public new SegmentPositionBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (SegmentPositionBuilder)base.ToMutable(model);
		}
	
		
		public bool AtStart
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.SegmentPosition.AtStartProperty, ref atStart0); }
		}
	
		
		public bool AtEnd
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.SegmentPosition.AtEndProperty, ref atEnd0); }
		}
	
		
		public double Position
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.SegmentPosition.PositionProperty, ref position0); }
		}
	
		
		public Side Side
		{
		    get { return this.GetValue<Side>(global::RailDsl.RailDslDescriptor.SegmentPosition.SideProperty, ref side0); }
		}
	
		
		public Orientation Orientation
		{
		    get { return this.GetValue<Orientation>(global::RailDsl.RailDslDescriptor.SegmentPosition.OrientationProperty, ref orientation0); }
		}
	
		
		public Segment Segment
		{
		    get { return this.GetReference<Segment>(global::RailDsl.RailDslDescriptor.SegmentPosition.SegmentProperty, ref segment0); }
		}
	}
	
	internal class SegmentPositionBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, SegmentPositionBuilder
	{
	
		internal SegmentPositionBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.SegmentPosition(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.SegmentPosition_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.SegmentPosition; }
		}
	
		public new SegmentPosition ToImmutable()
		{
			return (SegmentPosition)base.ToImmutable();
		}
	
		public new SegmentPosition ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (SegmentPosition)base.ToImmutable(model);
		}
	
		
		public bool AtStart
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.SegmentPosition.AtStartProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.SegmentPosition.AtStartProperty, value); }
		}
		
		void SegmentPositionBuilder.SetAtStartLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.AtStartProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetAtStartLazy(global::System.Func<SegmentPositionBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.AtStartProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetAtStartLazy(global::System.Func<SegmentPosition, bool> immutableLazy, global::System.Func<SegmentPositionBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.AtStartProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool AtEnd
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.SegmentPosition.AtEndProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.SegmentPosition.AtEndProperty, value); }
		}
		
		void SegmentPositionBuilder.SetAtEndLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.AtEndProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetAtEndLazy(global::System.Func<SegmentPositionBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.AtEndProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetAtEndLazy(global::System.Func<SegmentPosition, bool> immutableLazy, global::System.Func<SegmentPositionBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.AtEndProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Position
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.SegmentPosition.PositionProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.SegmentPosition.PositionProperty, value); }
		}
		
		void SegmentPositionBuilder.SetPositionLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.PositionProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.PositionProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetPositionLazy(global::System.Func<SegmentPosition, double> immutableLazy, global::System.Func<SegmentPositionBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public Side Side
		{
			get { return this.GetValue<Side>(global::RailDsl.RailDslDescriptor.SegmentPosition.SideProperty); }
			set { this.SetValue<Side>(global::RailDsl.RailDslDescriptor.SegmentPosition.SideProperty, value); }
		}
		
		void SegmentPositionBuilder.SetSideLazy(global::System.Func<Side> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.SideProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetSideLazy(global::System.Func<SegmentPositionBuilder, Side> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.SideProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetSideLazy(global::System.Func<SegmentPosition, Side> immutableLazy, global::System.Func<SegmentPositionBuilder, Side> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.SideProperty, immutableLazy, mutableLazy);
		}
	
		
		public Orientation Orientation
		{
			get { return this.GetValue<Orientation>(global::RailDsl.RailDslDescriptor.SegmentPosition.OrientationProperty); }
			set { this.SetValue<Orientation>(global::RailDsl.RailDslDescriptor.SegmentPosition.OrientationProperty, value); }
		}
		
		void SegmentPositionBuilder.SetOrientationLazy(global::System.Func<Orientation> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.OrientationProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetOrientationLazy(global::System.Func<SegmentPositionBuilder, Orientation> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.OrientationProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetOrientationLazy(global::System.Func<SegmentPosition, Orientation> immutableLazy, global::System.Func<SegmentPositionBuilder, Orientation> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.SegmentPosition.OrientationProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentBuilder Segment
		{
			get { return this.GetReference<SegmentBuilder>(global::RailDsl.RailDslDescriptor.SegmentPosition.SegmentProperty); }
			set { this.SetReference<SegmentBuilder>(global::RailDsl.RailDslDescriptor.SegmentPosition.SegmentProperty, value); }
		}
		
		void SegmentPositionBuilder.SetSegmentLazy(global::System.Func<SegmentBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentPosition.SegmentProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetSegmentLazy(global::System.Func<SegmentPositionBuilder, SegmentBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentPosition.SegmentProperty, lazy);
		}
		
		void SegmentPositionBuilder.SetSegmentLazy(global::System.Func<SegmentPosition, Segment> immutableLazy, global::System.Func<SegmentPositionBuilder, SegmentBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.SegmentPosition.SegmentProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class PointId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Point.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new PointImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new PointBuilderImpl(this, model, creating);
		}
	}
	
	internal class PointImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Point
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Vertex> inputs0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Vertex> outputs0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PointKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int selectedInput0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int selectedOutput0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool locked0;
	
		internal PointImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Point; }
		}
	
		public new PointBuilder ToMutable()
		{
			return (PointBuilder)base.ToMutable();
		}
	
		public new PointBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (PointBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RouteObjectBuilder RouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		RouteObjectBuilder RouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TrackObjectBuilder TrackObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		TrackObjectBuilder TrackObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty, ref length0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Vertex> Inputs
		{
		    get { return this.GetList<Vertex>(global::RailDsl.RailDslDescriptor.Point.InputsProperty, ref inputs0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Vertex> Outputs
		{
		    get { return this.GetList<Vertex>(global::RailDsl.RailDslDescriptor.Point.OutputsProperty, ref outputs0); }
		}
	
		
		public PointKind Kind
		{
		    get { return this.GetValue<PointKind>(global::RailDsl.RailDslDescriptor.Point.KindProperty, ref kind0); }
		}
	
		
		public int SelectedInput
		{
		    get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.Point.SelectedInputProperty, ref selectedInput0); }
		}
	
		
		public int SelectedOutput
		{
		    get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.Point.SelectedOutputProperty, ref selectedOutput0); }
		}
	
		
		public bool Locked
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Point.LockedProperty, ref locked0); }
		}
	}
	
	internal class PointBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, PointBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<VertexBuilder> inputs0;
		private global::MetaDslx.Modeling.MutableModelList<VertexBuilder> outputs0;
	
		internal PointBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Point(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Point_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Point; }
		}
	
		public new Point ToImmutable()
		{
			return (Point)base.ToImmutable();
		}
	
		public new Point ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Point)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RouteObject RouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RouteObject RouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TrackObject TrackObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TrackObject TrackObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.TrackObject.LengthProperty, value); }
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, lazy);
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<TrackObjectBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, lazy);
		}
		
		void TrackObjectBuilder.SetLengthLazy(global::System.Func<TrackObject, double> immutableLazy, global::System.Func<TrackObjectBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrackObject.LengthProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<VertexBuilder> Inputs
		{
			get { return this.GetList<VertexBuilder>(global::RailDsl.RailDslDescriptor.Point.InputsProperty, ref inputs0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<VertexBuilder> Outputs
		{
			get { return this.GetList<VertexBuilder>(global::RailDsl.RailDslDescriptor.Point.OutputsProperty, ref outputs0); }
		}
	
		
		public PointKind Kind
		{
			get { return this.GetValue<PointKind>(global::RailDsl.RailDslDescriptor.Point.KindProperty); }
			set { this.SetValue<PointKind>(global::RailDsl.RailDslDescriptor.Point.KindProperty, value); }
		}
		
		void PointBuilder.SetKindLazy(global::System.Func<PointKind> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.KindProperty, lazy);
		}
		
		void PointBuilder.SetKindLazy(global::System.Func<PointBuilder, PointKind> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.KindProperty, lazy);
		}
		
		void PointBuilder.SetKindLazy(global::System.Func<Point, PointKind> immutableLazy, global::System.Func<PointBuilder, PointKind> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.KindProperty, immutableLazy, mutableLazy);
		}
	
		
		public int SelectedInput
		{
			get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.Point.SelectedInputProperty); }
			set { this.SetValue<int>(global::RailDsl.RailDslDescriptor.Point.SelectedInputProperty, value); }
		}
		
		void PointBuilder.SetSelectedInputLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.SelectedInputProperty, lazy);
		}
		
		void PointBuilder.SetSelectedInputLazy(global::System.Func<PointBuilder, int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.SelectedInputProperty, lazy);
		}
		
		void PointBuilder.SetSelectedInputLazy(global::System.Func<Point, int> immutableLazy, global::System.Func<PointBuilder, int> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.SelectedInputProperty, immutableLazy, mutableLazy);
		}
	
		
		public int SelectedOutput
		{
			get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.Point.SelectedOutputProperty); }
			set { this.SetValue<int>(global::RailDsl.RailDslDescriptor.Point.SelectedOutputProperty, value); }
		}
		
		void PointBuilder.SetSelectedOutputLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.SelectedOutputProperty, lazy);
		}
		
		void PointBuilder.SetSelectedOutputLazy(global::System.Func<PointBuilder, int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.SelectedOutputProperty, lazy);
		}
		
		void PointBuilder.SetSelectedOutputLazy(global::System.Func<Point, int> immutableLazy, global::System.Func<PointBuilder, int> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.SelectedOutputProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Locked
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.Point.LockedProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.Point.LockedProperty, value); }
		}
		
		void PointBuilder.SetLockedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.LockedProperty, lazy);
		}
		
		void PointBuilder.SetLockedLazy(global::System.Func<PointBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.LockedProperty, lazy);
		}
		
		void PointBuilder.SetLockedLazy(global::System.Func<Point, bool> immutableLazy, global::System.Func<PointBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Point.LockedProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrackId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Track.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrackImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrackBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrackImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Track
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<TrackObject> elements0;
	
		internal TrackImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Track; }
		}
	
		public new TrackBuilder ToMutable()
		{
			return (TrackBuilder)base.ToMutable();
		}
	
		public new TrackBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrackBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<TrackObject> Elements
		{
		    get { return this.GetList<TrackObject>(global::RailDsl.RailDslDescriptor.Track.ElementsProperty, ref elements0); }
		}
	}
	
	internal class TrackBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrackBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<TrackObjectBuilder> elements0;
	
		internal TrackBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Track(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Track_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Track; }
		}
	
		public new Track ToImmutable()
		{
			return (Track)base.ToImmutable();
		}
	
		public new Track ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Track)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<TrackObjectBuilder> Elements
		{
			get { return this.GetList<TrackObjectBuilder>(global::RailDsl.RailDslDescriptor.Track.ElementsProperty, ref elements0); }
		}
	}
	
	internal class NamedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.NamedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, NamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal NamedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.NamedElement; }
		}
	
		public new NamedElementBuilder ToMutable()
		{
			return (NamedElementBuilder)base.ToMutable();
		}
	
		public new NamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NamedElementBuilder)base.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class NamedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, NamedElementBuilder
	{
	
		internal NamedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.NamedElement(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.NamedElement_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.NamedElement; }
		}
	
		public new NamedElement ToImmutable()
		{
			return (NamedElement)base.ToImmutable();
		}
	
		public new NamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (NamedElement)base.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrainId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.Train.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrainImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrainBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrainImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Train
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double speed0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<TrainSegment> segments0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double acceleration0;
	
		internal TrainImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Train; }
		}
	
		public new TrainBuilder ToMutable()
		{
			return (TrainBuilder)base.ToMutable();
		}
	
		public new TrainBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrainBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Train.LengthProperty, ref length0); }
		}
	
		
		public double Speed
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Train.SpeedProperty, ref speed0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<TrainSegment> Segments
		{
		    get { return this.GetList<TrainSegment>(global::RailDsl.RailDslDescriptor.Train.SegmentsProperty, ref segments0); }
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.Train.PositionProperty, ref position0); }
		}
	
		
		public double Acceleration
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Train.AccelerationProperty, ref acceleration0); }
		}
	}
	
	internal class TrainBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrainBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<TrainSegmentBuilder> segments0;
	
		internal TrainBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.Train(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.Train_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.Train; }
		}
	
		public new Train ToImmutable()
		{
			return (Train)base.ToImmutable();
		}
	
		public new Train ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Train)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Train.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.Train.LengthProperty, value); }
		}
		
		void TrainBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.LengthProperty, lazy);
		}
		
		void TrainBuilder.SetLengthLazy(global::System.Func<TrainBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.LengthProperty, lazy);
		}
		
		void TrainBuilder.SetLengthLazy(global::System.Func<Train, double> immutableLazy, global::System.Func<TrainBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.LengthProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Speed
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Train.SpeedProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.Train.SpeedProperty, value); }
		}
		
		void TrainBuilder.SetSpeedLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.SpeedProperty, lazy);
		}
		
		void TrainBuilder.SetSpeedLazy(global::System.Func<TrainBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.SpeedProperty, lazy);
		}
		
		void TrainBuilder.SetSpeedLazy(global::System.Func<Train, double> immutableLazy, global::System.Func<TrainBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.SpeedProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<TrainSegmentBuilder> Segments
		{
			get { return this.GetList<TrainSegmentBuilder>(global::RailDsl.RailDslDescriptor.Train.SegmentsProperty, ref segments0); }
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.Train.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.Train.PositionProperty, value); }
		}
		
		void TrainBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Train.PositionProperty, lazy);
		}
		
		void TrainBuilder.SetPositionLazy(global::System.Func<TrainBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.Train.PositionProperty, lazy);
		}
		
		void TrainBuilder.SetPositionLazy(global::System.Func<Train, SegmentPosition> immutableLazy, global::System.Func<TrainBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.Train.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Acceleration
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.Train.AccelerationProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.Train.AccelerationProperty, value); }
		}
		
		void TrainBuilder.SetAccelerationLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.AccelerationProperty, lazy);
		}
		
		void TrainBuilder.SetAccelerationLazy(global::System.Func<TrainBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.AccelerationProperty, lazy);
		}
		
		void TrainBuilder.SetAccelerationLazy(global::System.Func<Train, double> immutableLazy, global::System.Func<TrainBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.Train.AccelerationProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrainSegmentId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.TrainSegment.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrainSegmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrainSegmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrainSegmentImpl : global::MetaDslx.Modeling.ImmutableObjectBase, TrainSegment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SegmentPosition position0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double length0;
	
		internal TrainSegmentImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainSegment; }
		}
	
		public new TrainSegmentBuilder ToMutable()
		{
			return (TrainSegmentBuilder)base.ToMutable();
		}
	
		public new TrainSegmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrainSegmentBuilder)base.ToMutable(model);
		}
	
		
		public SegmentPosition Position
		{
		    get { return this.GetReference<SegmentPosition>(global::RailDsl.RailDslDescriptor.TrainSegment.PositionProperty, ref position0); }
		}
	
		
		public double Length
		{
		    get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrainSegment.LengthProperty, ref length0); }
		}
	}
	
	internal class TrainSegmentBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrainSegmentBuilder
	{
	
		internal TrainSegmentBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.TrainSegment(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.TrainSegment_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainSegment; }
		}
	
		public new TrainSegment ToImmutable()
		{
			return (TrainSegment)base.ToImmutable();
		}
	
		public new TrainSegment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TrainSegment)base.ToImmutable(model);
		}
	
		
		public SegmentPositionBuilder Position
		{
			get { return this.GetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.TrainSegment.PositionProperty); }
			set { this.SetReference<SegmentPositionBuilder>(global::RailDsl.RailDslDescriptor.TrainSegment.PositionProperty, value); }
		}
		
		void TrainSegmentBuilder.SetPositionLazy(global::System.Func<SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainSegment.PositionProperty, lazy);
		}
		
		void TrainSegmentBuilder.SetPositionLazy(global::System.Func<TrainSegmentBuilder, SegmentPositionBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainSegment.PositionProperty, lazy);
		}
		
		void TrainSegmentBuilder.SetPositionLazy(global::System.Func<TrainSegment, SegmentPosition> immutableLazy, global::System.Func<TrainSegmentBuilder, SegmentPositionBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainSegment.PositionProperty, immutableLazy, mutableLazy);
		}
	
		
		public double Length
		{
			get { return this.GetValue<double>(global::RailDsl.RailDslDescriptor.TrainSegment.LengthProperty); }
			set { this.SetValue<double>(global::RailDsl.RailDslDescriptor.TrainSegment.LengthProperty, value); }
		}
		
		void TrainSegmentBuilder.SetLengthLazy(global::System.Func<double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainSegment.LengthProperty, lazy);
		}
		
		void TrainSegmentBuilder.SetLengthLazy(global::System.Func<TrainSegmentBuilder, double> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainSegment.LengthProperty, lazy);
		}
		
		void TrainSegmentBuilder.SetLengthLazy(global::System.Func<TrainSegment, double> immutableLazy, global::System.Func<TrainSegmentBuilder, double> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainSegment.LengthProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class RouteObjectId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.RouteObject.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RouteObjectImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RouteObjectBuilderImpl(this, model, creating);
		}
	}
	
	internal class RouteObjectImpl : global::MetaDslx.Modeling.ImmutableObjectBase, RouteObject
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool error0;
	
		internal RouteObjectImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.RouteObject; }
		}
	
		public new RouteObjectBuilder ToMutable()
		{
			return (RouteObjectBuilder)base.ToMutable();
		}
	
		public new RouteObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RouteObjectBuilder)base.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public bool Error
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, ref error0); }
		}
	}
	
	internal class RouteObjectBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RouteObjectBuilder
	{
	
		internal RouteObjectBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.RouteObject(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.RouteObject_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.RouteObject; }
		}
	
		public new RouteObject ToImmutable()
		{
			return (RouteObject)base.ToImmutable();
		}
	
		public new RouteObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RouteObject)base.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.RouteObject.SpeedLimitProperty, value); }
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, lazy);
		}
		
		void RouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<RouteObject, SpeedLimit> immutableLazy, global::System.Func<RouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Error
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.RouteObject.ErrorProperty, value); }
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObjectBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, lazy);
		}
		
		void RouteObjectBuilder.SetErrorLazy(global::System.Func<RouteObject, bool> immutableLazy, global::System.Func<RouteObjectBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.RouteObject.ErrorProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrainRouteId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.TrainRoute.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrainRouteImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrainRouteBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrainRouteImpl : global::MetaDslx.Modeling.ImmutableObjectBase, TrainRoute
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<TrainRouteObject> path0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TrainRouteKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Signal startSignal0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Signal endSignal0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<TrainRouteObject> protectionObjects0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<TrainRoute> conflictingRoutes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool locked0;
	
		internal TrainRouteImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRoute; }
		}
	
		public new TrainRouteBuilder ToMutable()
		{
			return (TrainRouteBuilder)base.ToMutable();
		}
	
		public new TrainRouteBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrainRouteBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<TrainRouteObject> Path
		{
		    get { return this.GetList<TrainRouteObject>(global::RailDsl.RailDslDescriptor.TrainRoute.PathProperty, ref path0); }
		}
	
		
		public TrainRouteKind Kind
		{
		    get { return this.GetValue<TrainRouteKind>(global::RailDsl.RailDslDescriptor.TrainRoute.KindProperty, ref kind0); }
		}
	
		
		public Signal StartSignal
		{
		    get { return this.GetReference<Signal>(global::RailDsl.RailDslDescriptor.TrainRoute.StartSignalProperty, ref startSignal0); }
		}
	
		
		public Signal EndSignal
		{
		    get { return this.GetReference<Signal>(global::RailDsl.RailDslDescriptor.TrainRoute.EndSignalProperty, ref endSignal0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<TrainRouteObject> ProtectionObjects
		{
		    get { return this.GetList<TrainRouteObject>(global::RailDsl.RailDslDescriptor.TrainRoute.ProtectionObjectsProperty, ref protectionObjects0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<TrainRoute> ConflictingRoutes
		{
		    get { return this.GetList<TrainRoute>(global::RailDsl.RailDslDescriptor.TrainRoute.ConflictingRoutesProperty, ref conflictingRoutes0); }
		}
	
		
		public bool Locked
		{
		    get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.TrainRoute.LockedProperty, ref locked0); }
		}
	}
	
	internal class TrainRouteBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrainRouteBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<TrainRouteObjectBuilder> path0;
		private global::MetaDslx.Modeling.MutableModelList<TrainRouteObjectBuilder> protectionObjects0;
		private global::MetaDslx.Modeling.MutableModelList<TrainRouteBuilder> conflictingRoutes0;
	
		internal TrainRouteBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.TrainRoute(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.TrainRoute_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRoute; }
		}
	
		public new TrainRoute ToImmutable()
		{
			return (TrainRoute)base.ToImmutable();
		}
	
		public new TrainRoute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TrainRoute)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::RailDsl.RailDslDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<TrainRouteObjectBuilder> Path
		{
			get { return this.GetList<TrainRouteObjectBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.PathProperty, ref path0); }
		}
	
		
		public TrainRouteKind Kind
		{
			get { return this.GetValue<TrainRouteKind>(global::RailDsl.RailDslDescriptor.TrainRoute.KindProperty); }
			set { this.SetValue<TrainRouteKind>(global::RailDsl.RailDslDescriptor.TrainRoute.KindProperty, value); }
		}
		
		void TrainRouteBuilder.SetKindLazy(global::System.Func<TrainRouteKind> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoute.KindProperty, lazy);
		}
		
		void TrainRouteBuilder.SetKindLazy(global::System.Func<TrainRouteBuilder, TrainRouteKind> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoute.KindProperty, lazy);
		}
		
		void TrainRouteBuilder.SetKindLazy(global::System.Func<TrainRoute, TrainRouteKind> immutableLazy, global::System.Func<TrainRouteBuilder, TrainRouteKind> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoute.KindProperty, immutableLazy, mutableLazy);
		}
	
		
		public SignalBuilder StartSignal
		{
			get { return this.GetReference<SignalBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.StartSignalProperty); }
			set { this.SetReference<SignalBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.StartSignalProperty, value); }
		}
		
		void TrainRouteBuilder.SetStartSignalLazy(global::System.Func<SignalBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoute.StartSignalProperty, lazy);
		}
		
		void TrainRouteBuilder.SetStartSignalLazy(global::System.Func<TrainRouteBuilder, SignalBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoute.StartSignalProperty, lazy);
		}
		
		void TrainRouteBuilder.SetStartSignalLazy(global::System.Func<TrainRoute, Signal> immutableLazy, global::System.Func<TrainRouteBuilder, SignalBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoute.StartSignalProperty, immutableLazy, mutableLazy);
		}
	
		
		public SignalBuilder EndSignal
		{
			get { return this.GetReference<SignalBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.EndSignalProperty); }
			set { this.SetReference<SignalBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.EndSignalProperty, value); }
		}
		
		void TrainRouteBuilder.SetEndSignalLazy(global::System.Func<SignalBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoute.EndSignalProperty, lazy);
		}
		
		void TrainRouteBuilder.SetEndSignalLazy(global::System.Func<TrainRouteBuilder, SignalBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoute.EndSignalProperty, lazy);
		}
		
		void TrainRouteBuilder.SetEndSignalLazy(global::System.Func<TrainRoute, Signal> immutableLazy, global::System.Func<TrainRouteBuilder, SignalBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoute.EndSignalProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<TrainRouteObjectBuilder> ProtectionObjects
		{
			get { return this.GetList<TrainRouteObjectBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.ProtectionObjectsProperty, ref protectionObjects0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<TrainRouteBuilder> ConflictingRoutes
		{
			get { return this.GetList<TrainRouteBuilder>(global::RailDsl.RailDslDescriptor.TrainRoute.ConflictingRoutesProperty, ref conflictingRoutes0); }
		}
	
		
		public bool Locked
		{
			get { return this.GetValue<bool>(global::RailDsl.RailDslDescriptor.TrainRoute.LockedProperty); }
			set { this.SetValue<bool>(global::RailDsl.RailDslDescriptor.TrainRoute.LockedProperty, value); }
		}
		
		void TrainRouteBuilder.SetLockedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoute.LockedProperty, lazy);
		}
		
		void TrainRouteBuilder.SetLockedLazy(global::System.Func<TrainRouteBuilder, bool> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoute.LockedProperty, lazy);
		}
		
		void TrainRouteBuilder.SetLockedLazy(global::System.Func<TrainRoute, bool> immutableLazy, global::System.Func<TrainRouteBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoute.LockedProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrainRouteObjectId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.TrainRouteObject.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrainRouteObjectImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrainRouteObjectBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrainRouteObjectImpl : global::MetaDslx.Modeling.ImmutableObjectBase, TrainRouteObject
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
	
		internal TrainRouteObjectImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRouteObject; }
		}
	
		public new TrainRouteObjectBuilder ToMutable()
		{
			return (TrainRouteObjectBuilder)base.ToMutable();
		}
	
		public new TrainRouteObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrainRouteObjectBuilder)base.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	}
	
	internal class TrainRouteObjectBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrainRouteObjectBuilder
	{
	
		internal TrainRouteObjectBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.TrainRouteObject(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.TrainRouteObject_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRouteObject; }
		}
	
		public new TrainRouteObject ToImmutable()
		{
			return (TrainRouteObject)base.ToImmutable();
		}
	
		public new TrainRouteObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TrainRouteObject)base.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, value); }
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, lazy);
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<TrainRouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, lazy);
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<TrainRouteObject, SpeedLimit> immutableLazy, global::System.Func<TrainRouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrainRoutePointId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.TrainRoutePoint.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrainRoutePointImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrainRoutePointBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrainRoutePointImpl : global::MetaDslx.Modeling.ImmutableObjectBase, TrainRoutePoint
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Point originalPoint0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int selectedInput0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int selectedOutput0;
	
		internal TrainRoutePointImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRoutePoint; }
		}
	
		public new TrainRoutePointBuilder ToMutable()
		{
			return (TrainRoutePointBuilder)base.ToMutable();
		}
	
		public new TrainRoutePointBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrainRoutePointBuilder)base.ToMutable(model);
		}
	
		TrainRouteObjectBuilder TrainRouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		TrainRouteObjectBuilder TrainRouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public Point OriginalPoint
		{
		    get { return this.GetReference<Point>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.OriginalPointProperty, ref originalPoint0); }
		}
	
		
		public int SelectedInput
		{
		    get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.SelectedInputProperty, ref selectedInput0); }
		}
	
		
		public int SelectedOutput
		{
		    get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty, ref selectedOutput0); }
		}
	}
	
	internal class TrainRoutePointBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrainRoutePointBuilder
	{
	
		internal TrainRoutePointBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.TrainRoutePoint(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.TrainRoutePoint_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRoutePoint; }
		}
	
		public new TrainRoutePoint ToImmutable()
		{
			return (TrainRoutePoint)base.ToImmutable();
		}
	
		public new TrainRoutePoint ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TrainRoutePoint)base.ToImmutable(model);
		}
	
		TrainRouteObject TrainRouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TrainRouteObject TrainRouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, value); }
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, lazy);
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<TrainRouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, lazy);
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<TrainRouteObject, SpeedLimit> immutableLazy, global::System.Func<TrainRouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public PointBuilder OriginalPoint
		{
			get { return this.GetReference<PointBuilder>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.OriginalPointProperty); }
			set { this.SetReference<PointBuilder>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.OriginalPointProperty, value); }
		}
		
		void TrainRoutePointBuilder.SetOriginalPointLazy(global::System.Func<PointBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoutePoint.OriginalPointProperty, lazy);
		}
		
		void TrainRoutePointBuilder.SetOriginalPointLazy(global::System.Func<TrainRoutePointBuilder, PointBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoutePoint.OriginalPointProperty, lazy);
		}
		
		void TrainRoutePointBuilder.SetOriginalPointLazy(global::System.Func<TrainRoutePoint, Point> immutableLazy, global::System.Func<TrainRoutePointBuilder, PointBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRoutePoint.OriginalPointProperty, immutableLazy, mutableLazy);
		}
	
		
		public int SelectedInput
		{
			get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.SelectedInputProperty); }
			set { this.SetValue<int>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.SelectedInputProperty, value); }
		}
		
		void TrainRoutePointBuilder.SetSelectedInputLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoutePoint.SelectedInputProperty, lazy);
		}
		
		void TrainRoutePointBuilder.SetSelectedInputLazy(global::System.Func<TrainRoutePointBuilder, int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoutePoint.SelectedInputProperty, lazy);
		}
		
		void TrainRoutePointBuilder.SetSelectedInputLazy(global::System.Func<TrainRoutePoint, int> immutableLazy, global::System.Func<TrainRoutePointBuilder, int> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoutePoint.SelectedInputProperty, immutableLazy, mutableLazy);
		}
	
		
		public int SelectedOutput
		{
			get { return this.GetValue<int>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty); }
			set { this.SetValue<int>(global::RailDsl.RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty, value); }
		}
		
		void TrainRoutePointBuilder.SetSelectedOutputLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty, lazy);
		}
		
		void TrainRoutePointBuilder.SetSelectedOutputLazy(global::System.Func<TrainRoutePointBuilder, int> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty, lazy);
		}
		
		void TrainRoutePointBuilder.SetSelectedOutputLazy(global::System.Func<TrainRoutePoint, int> immutableLazy, global::System.Func<TrainRoutePointBuilder, int> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRoutePoint.SelectedOutputProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class TrainRouteSegmentId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::RailDsl.RailDslDescriptor.TrainRouteSegment.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TrainRouteSegmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TrainRouteSegmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class TrainRouteSegmentImpl : global::MetaDslx.Modeling.ImmutableObjectBase, TrainRouteSegment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SpeedLimit speedLimit0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Segment originalSegment0;
	
		internal TrainRouteSegmentImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRouteSegment; }
		}
	
		public new TrainRouteSegmentBuilder ToMutable()
		{
			return (TrainRouteSegmentBuilder)base.ToMutable();
		}
	
		public new TrainRouteSegmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TrainRouteSegmentBuilder)base.ToMutable(model);
		}
	
		TrainRouteObjectBuilder TrainRouteObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		TrainRouteObjectBuilder TrainRouteObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
		    get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, ref speedLimit0); }
		}
	
		
		public Segment OriginalSegment
		{
		    get { return this.GetReference<Segment>(global::RailDsl.RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty, ref originalSegment0); }
		}
	}
	
	internal class TrainRouteSegmentBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, TrainRouteSegmentBuilder
	{
	
		internal TrainRouteSegmentBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			RailDslImplementationProvider.Implementation.TrainRouteSegment(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			RailDslImplementationProvider.Implementation.TrainRouteSegment_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::RailDsl.RailDslInstance.MMetaModel; }
		}
	
		public override global::.MetaClass MMetaClass
		{
			get { return RailDslInstance.TrainRouteSegment; }
		}
	
		public new TrainRouteSegment ToImmutable()
		{
			return (TrainRouteSegment)base.ToImmutable();
		}
	
		public new TrainRouteSegment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TrainRouteSegment)base.ToImmutable(model);
		}
	
		TrainRouteObject TrainRouteObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TrainRouteObject TrainRouteObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SpeedLimit SpeedLimit
		{
			get { return this.GetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty); }
			set { this.SetValue<SpeedLimit>(global::RailDsl.RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, value); }
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, lazy);
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<TrainRouteObjectBuilder, SpeedLimit> lazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, lazy);
		}
		
		void TrainRouteObjectBuilder.SetSpeedLimitLazy(global::System.Func<TrainRouteObject, SpeedLimit> immutableLazy, global::System.Func<TrainRouteObjectBuilder, SpeedLimit> mutableLazy)
		{
			this.SetLazyValue(RailDslDescriptor.TrainRouteObject.SpeedLimitProperty, immutableLazy, mutableLazy);
		}
	
		
		public SegmentBuilder OriginalSegment
		{
			get { return this.GetReference<SegmentBuilder>(global::RailDsl.RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty); }
			set { this.SetReference<SegmentBuilder>(global::RailDsl.RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty, value); }
		}
		
		void TrainRouteSegmentBuilder.SetOriginalSegmentLazy(global::System.Func<SegmentBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty, lazy);
		}
		
		void TrainRouteSegmentBuilder.SetOriginalSegmentLazy(global::System.Func<TrainRouteSegmentBuilder, SegmentBuilder> lazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty, lazy);
		}
		
		void TrainRouteSegmentBuilder.SetOriginalSegmentLazy(global::System.Func<TrainRouteSegment, Segment> immutableLazy, global::System.Func<TrainRouteSegmentBuilder, SegmentBuilder> mutableLazy)
		{
			this.SetLazyReference(RailDslDescriptor.TrainRouteSegment.OriginalSegmentProperty, immutableLazy, mutableLazy);
		}
	}

	internal class RailDslBuilderInstance
	{
		internal static RailDslBuilderInstance instance = new RailDslBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Modeling.MutableModel MModel;
		internal global::MetaDslx.Modeling.MutableModelGroup MModelGroup;
	
	
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp1;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder SpeedLimit;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp18;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp19;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder PointKind;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp16;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp17;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp20;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder VertexKind;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp21;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp22;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder Orientation;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp11;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder Side;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp10;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder TrainRouteKind;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp12;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Station;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Station_Declarations;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Declaration;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder TrackObject;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrackObject_Length;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Vertex;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Vertex_Kind;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Segment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Segment_Start;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Segment_End;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Segment_Objects;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder SegmentObject;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentObject_Position;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Derailer;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Derailer_Active;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LevelCrossing;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LevelCrossing_Closed;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LevelCrossing_Length;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Signal;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Signal_DistantFor;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Signal_Main;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Signal_Shunting;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Platform;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Platform_Length;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder SegmentPosition;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentPosition_AtStart;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentPosition_AtEnd;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentPosition_Position;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentPosition_Side;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentPosition_Orientation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder SegmentPosition_Segment;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Point;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Point_Inputs;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Point_Outputs;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Point_Kind;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Point_SelectedInput;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Point_SelectedOutput;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Point_Locked;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Track;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Track_Elements;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder NamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder NamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Train;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Train_Length;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Train_Speed;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Train_Segments;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Train_Position;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Train_Acceleration;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder TrainSegment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainSegment_Position;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainSegment_Length;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RouteObject;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RouteObject_SpeedLimit;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RouteObject_Error;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder TrainRoute;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_Path;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_Kind;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_StartSignal;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_EndSignal;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_ProtectionObjects;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_ConflictingRoutes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoute_Locked;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder TrainRouteObject;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRouteObject_SpeedLimit;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder TrainRoutePoint;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoutePoint_OriginalPoint;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoutePoint_SelectedInput;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRoutePoint_SelectedOutput;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder TrainRouteSegment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder TrainRouteSegment_OriginalSegment;
		private global::MetaDslx.Languages.Meta.Model.MetaModelBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp26;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp27;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp28;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp29;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp30;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp31;
	
		internal RailDslBuilderInstance()
		{
			this.MModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.MModelGroup.AddReference(global::.MetaInstance.MModel.ToMutable(true));
			this.MModel = this.MModelGroup.CreateModel("RailDsl");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			this.CreateInstances();
			RailDslImplementationProvider.Implementation.RailDslBuilderInstance(this);
	        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)
	        {
	            obj.MMakeCreated();
	        }
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.MModel.EvaluateLazyValues();
		}
	
		private void CreateInstances()
		{
			global::.MetaFactory factory = new global::.MetaFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
			RailDslFactory constantFactory = new RailDslFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
	
	
			__tmp1 = factory.MetaNamespace();
			SpeedLimit = factory.MetaEnum();
			__tmp5 = factory.MetaEnumLiteral();
			__tmp13 = factory.MetaEnumLiteral();
			__tmp14 = factory.MetaEnumLiteral();
			__tmp18 = factory.MetaEnumLiteral();
			__tmp19 = factory.MetaEnumLiteral();
			PointKind = factory.MetaEnum();
			__tmp6 = factory.MetaEnumLiteral();
			__tmp15 = factory.MetaEnumLiteral();
			__tmp16 = factory.MetaEnumLiteral();
			__tmp17 = factory.MetaEnumLiteral();
			__tmp20 = factory.MetaEnumLiteral();
			VertexKind = factory.MetaEnum();
			__tmp4 = factory.MetaEnumLiteral();
			__tmp21 = factory.MetaEnumLiteral();
			__tmp22 = factory.MetaEnumLiteral();
			Orientation = factory.MetaEnum();
			__tmp3 = factory.MetaEnumLiteral();
			__tmp11 = factory.MetaEnumLiteral();
			Side = factory.MetaEnum();
			__tmp7 = factory.MetaEnumLiteral();
			__tmp8 = factory.MetaEnumLiteral();
			__tmp10 = factory.MetaEnumLiteral();
			TrainRouteKind = factory.MetaEnum();
			__tmp9 = factory.MetaEnumLiteral();
			__tmp12 = factory.MetaEnumLiteral();
			Station = factory.MetaClass();
			Station_Declarations = factory.MetaProperty();
			Declaration = factory.MetaClass();
			TrackObject = factory.MetaClass();
			TrackObject_Length = factory.MetaProperty();
			Vertex = factory.MetaClass();
			Vertex_Kind = factory.MetaProperty();
			Segment = factory.MetaClass();
			Segment_Start = factory.MetaProperty();
			Segment_End = factory.MetaProperty();
			Segment_Objects = factory.MetaProperty();
			SegmentObject = factory.MetaClass();
			SegmentObject_Position = factory.MetaProperty();
			Derailer = factory.MetaClass();
			Derailer_Active = factory.MetaProperty();
			LevelCrossing = factory.MetaClass();
			LevelCrossing_Closed = factory.MetaProperty();
			LevelCrossing_Length = factory.MetaProperty();
			Signal = factory.MetaClass();
			Signal_DistantFor = factory.MetaProperty();
			Signal_Main = factory.MetaProperty();
			Signal_Shunting = factory.MetaProperty();
			Platform = factory.MetaClass();
			Platform_Length = factory.MetaProperty();
			SegmentPosition = factory.MetaClass();
			SegmentPosition_AtStart = factory.MetaProperty();
			SegmentPosition_AtEnd = factory.MetaProperty();
			SegmentPosition_Position = factory.MetaProperty();
			SegmentPosition_Side = factory.MetaProperty();
			SegmentPosition_Orientation = factory.MetaProperty();
			SegmentPosition_Segment = factory.MetaProperty();
			Point = factory.MetaClass();
			Point_Inputs = factory.MetaProperty();
			Point_Outputs = factory.MetaProperty();
			Point_Kind = factory.MetaProperty();
			Point_SelectedInput = factory.MetaProperty();
			Point_SelectedOutput = factory.MetaProperty();
			Point_Locked = factory.MetaProperty();
			Track = factory.MetaClass();
			Track_Elements = factory.MetaProperty();
			NamedElement = factory.MetaClass();
			NamedElement_Name = factory.MetaProperty();
			Train = factory.MetaClass();
			Train_Length = factory.MetaProperty();
			Train_Speed = factory.MetaProperty();
			Train_Segments = factory.MetaProperty();
			Train_Position = factory.MetaProperty();
			Train_Acceleration = factory.MetaProperty();
			TrainSegment = factory.MetaClass();
			TrainSegment_Position = factory.MetaProperty();
			TrainSegment_Length = factory.MetaProperty();
			RouteObject = factory.MetaClass();
			RouteObject_SpeedLimit = factory.MetaProperty();
			RouteObject_Error = factory.MetaProperty();
			TrainRoute = factory.MetaClass();
			TrainRoute_Path = factory.MetaProperty();
			TrainRoute_Kind = factory.MetaProperty();
			TrainRoute_StartSignal = factory.MetaProperty();
			TrainRoute_EndSignal = factory.MetaProperty();
			TrainRoute_ProtectionObjects = factory.MetaProperty();
			TrainRoute_ConflictingRoutes = factory.MetaProperty();
			TrainRoute_Locked = factory.MetaProperty();
			TrainRouteObject = factory.MetaClass();
			TrainRouteObject_SpeedLimit = factory.MetaProperty();
			TrainRoutePoint = factory.MetaClass();
			TrainRoutePoint_OriginalPoint = factory.MetaProperty();
			TrainRoutePoint_SelectedInput = factory.MetaProperty();
			TrainRoutePoint_SelectedOutput = factory.MetaProperty();
			TrainRouteSegment = factory.MetaClass();
			TrainRouteSegment_OriginalSegment = factory.MetaProperty();
			__tmp2 = factory.MetaModel();
			__tmp23 = factory.MetaCollectionType();
			__tmp24 = factory.MetaCollectionType();
			__tmp25 = factory.MetaCollectionType();
			__tmp26 = factory.MetaCollectionType();
			__tmp27 = factory.MetaCollectionType();
			__tmp28 = factory.MetaCollectionType();
			__tmp29 = factory.MetaCollectionType();
			__tmp30 = factory.MetaCollectionType();
			__tmp31 = factory.MetaCollectionType();
	
			__tmp1.Documentation = null;
			__tmp1.Name = "RailDsl";
			// __tmp1.Namespace = null;
			__tmp1.SetDefinedMetaModelLazy(() => __tmp2);
			__tmp1.Declarations.AddLazy(() => SpeedLimit);
			__tmp1.Declarations.AddLazy(() => PointKind);
			__tmp1.Declarations.AddLazy(() => VertexKind);
			__tmp1.Declarations.AddLazy(() => Orientation);
			__tmp1.Declarations.AddLazy(() => Side);
			__tmp1.Declarations.AddLazy(() => TrainRouteKind);
			__tmp1.Declarations.AddLazy(() => Station);
			__tmp1.Declarations.AddLazy(() => Declaration);
			__tmp1.Declarations.AddLazy(() => TrackObject);
			__tmp1.Declarations.AddLazy(() => Vertex);
			__tmp1.Declarations.AddLazy(() => Segment);
			__tmp1.Declarations.AddLazy(() => SegmentObject);
			__tmp1.Declarations.AddLazy(() => Derailer);
			__tmp1.Declarations.AddLazy(() => LevelCrossing);
			__tmp1.Declarations.AddLazy(() => Signal);
			__tmp1.Declarations.AddLazy(() => Platform);
			__tmp1.Declarations.AddLazy(() => SegmentPosition);
			__tmp1.Declarations.AddLazy(() => Point);
			__tmp1.Declarations.AddLazy(() => Track);
			__tmp1.Declarations.AddLazy(() => NamedElement);
			__tmp1.Declarations.AddLazy(() => Train);
			__tmp1.Declarations.AddLazy(() => TrainSegment);
			__tmp1.Declarations.AddLazy(() => RouteObject);
			__tmp1.Declarations.AddLazy(() => TrainRoute);
			__tmp1.Declarations.AddLazy(() => TrainRouteObject);
			__tmp1.Declarations.AddLazy(() => TrainRoutePoint);
			__tmp1.Declarations.AddLazy(() => TrainRouteSegment);
			SpeedLimit.Documentation = "";
			SpeedLimit.Name = "SpeedLimit";
			SpeedLimit.SetNamespaceLazy(() => __tmp1);
			SpeedLimit.EnumLiterals.AddLazy(() => __tmp5);
			SpeedLimit.EnumLiterals.AddLazy(() => __tmp13);
			SpeedLimit.EnumLiterals.AddLazy(() => __tmp14);
			SpeedLimit.EnumLiterals.AddLazy(() => __tmp18);
			SpeedLimit.EnumLiterals.AddLazy(() => __tmp19);
			__tmp5.Documentation = "";
			__tmp5.Name = "Stop";
			__tmp5.SetEnumLazy(() => SpeedLimit);
			__tmp13.Documentation = "";
			__tmp13.Name = "Speed40";
			__tmp13.SetEnumLazy(() => SpeedLimit);
			__tmp14.Documentation = "";
			__tmp14.Name = "Speed80";
			__tmp14.SetEnumLazy(() => SpeedLimit);
			__tmp18.Documentation = "";
			__tmp18.Name = "Speed120";
			__tmp18.SetEnumLazy(() => SpeedLimit);
			__tmp19.Documentation = "";
			__tmp19.Name = "Max";
			__tmp19.SetEnumLazy(() => SpeedLimit);
			PointKind.Documentation = "";
			PointKind.Name = "PointKind";
			PointKind.SetNamespaceLazy(() => __tmp1);
			PointKind.EnumLiterals.AddLazy(() => __tmp6);
			PointKind.EnumLiterals.AddLazy(() => __tmp15);
			PointKind.EnumLiterals.AddLazy(() => __tmp16);
			PointKind.EnumLiterals.AddLazy(() => __tmp17);
			PointKind.EnumLiterals.AddLazy(() => __tmp20);
			__tmp6.Documentation = "";
			__tmp6.Name = "FixedCrossing";
			__tmp6.SetEnumLazy(() => PointKind);
			__tmp15.Documentation = "";
			__tmp15.Name = "SimplePoint";
			__tmp15.SetEnumLazy(() => PointKind);
			__tmp16.Documentation = "";
			__tmp16.Name = "DoublePoint";
			__tmp16.SetEnumLazy(() => PointKind);
			__tmp17.Documentation = "";
			__tmp17.Name = "SingleSlipPoint";
			__tmp17.SetEnumLazy(() => PointKind);
			__tmp20.Documentation = "";
			__tmp20.Name = "DoubleSlipPoint";
			__tmp20.SetEnumLazy(() => PointKind);
			VertexKind.Documentation = "";
			VertexKind.Name = "VertexKind";
			VertexKind.SetNamespaceLazy(() => __tmp1);
			VertexKind.EnumLiterals.AddLazy(() => __tmp4);
			VertexKind.EnumLiterals.AddLazy(() => __tmp21);
			VertexKind.EnumLiterals.AddLazy(() => __tmp22);
			__tmp4.Documentation = "";
			__tmp4.Name = "InnerVertex";
			__tmp4.SetEnumLazy(() => VertexKind);
			__tmp21.Documentation = "";
			__tmp21.Name = "TrackEnd";
			__tmp21.SetEnumLazy(() => VertexKind);
			__tmp22.Documentation = "";
			__tmp22.Name = "StationBorder";
			__tmp22.SetEnumLazy(() => VertexKind);
			Orientation.Documentation = "";
			Orientation.Name = "Orientation";
			Orientation.SetNamespaceLazy(() => __tmp1);
			Orientation.EnumLiterals.AddLazy(() => __tmp3);
			Orientation.EnumLiterals.AddLazy(() => __tmp11);
			__tmp3.Documentation = "";
			__tmp3.Name = "Forwards";
			__tmp3.SetEnumLazy(() => Orientation);
			__tmp11.Documentation = "";
			__tmp11.Name = "Backwards";
			__tmp11.SetEnumLazy(() => Orientation);
			Side.Documentation = "";
			Side.Name = "Side";
			Side.SetNamespaceLazy(() => __tmp1);
			Side.EnumLiterals.AddLazy(() => __tmp7);
			Side.EnumLiterals.AddLazy(() => __tmp8);
			Side.EnumLiterals.AddLazy(() => __tmp10);
			__tmp7.Documentation = "";
			__tmp7.Name = "Both";
			__tmp7.SetEnumLazy(() => Side);
			__tmp8.Documentation = "";
			__tmp8.Name = "Right";
			__tmp8.SetEnumLazy(() => Side);
			__tmp10.Documentation = "";
			__tmp10.Name = "Left";
			__tmp10.SetEnumLazy(() => Side);
			TrainRouteKind.Documentation = "";
			TrainRouteKind.Name = "TrainRouteKind";
			TrainRouteKind.SetNamespaceLazy(() => __tmp1);
			TrainRouteKind.EnumLiterals.AddLazy(() => __tmp9);
			TrainRouteKind.EnumLiterals.AddLazy(() => __tmp12);
			__tmp9.Documentation = "";
			__tmp9.Name = "Main";
			__tmp9.SetEnumLazy(() => TrainRouteKind);
			__tmp12.Documentation = "";
			__tmp12.Name = "Shunting";
			__tmp12.SetEnumLazy(() => TrainRouteKind);
			Station.Documentation = "";
			Station.Name = "Station";
			Station.SetNamespaceLazy(() => __tmp1);
			// Station.IsAbstract = null;
			Station.SuperClasses.AddLazy(() => NamedElement);
			Station.Properties.AddLazy(() => Station_Declarations);
			Station_Declarations.SetTypeLazy(() => __tmp24);
			Station_Declarations.Documentation = "";
			Station_Declarations.Name = "Declarations";
			// Station_Declarations.Kind = null;
			Station_Declarations.SetClassLazy(() => Station);
			Station_Declarations.DefaultValue = null;
			Station_Declarations.IsContainment = true;
			Declaration.Documentation = "";
			Declaration.Name = "Declaration";
			Declaration.SetNamespaceLazy(() => __tmp1);
			// Declaration.IsAbstract = null;
			Declaration.SuperClasses.AddLazy(() => NamedElement);
			TrackObject.Documentation = "";
			TrackObject.Name = "TrackObject";
			TrackObject.SetNamespaceLazy(() => __tmp1);
			// TrackObject.IsAbstract = null;
			TrackObject.SuperClasses.AddLazy(() => Declaration);
			TrackObject.SuperClasses.AddLazy(() => RouteObject);
			TrackObject.Properties.AddLazy(() => TrackObject_Length);
			TrackObject_Length.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			TrackObject_Length.Documentation = "";
			TrackObject_Length.Name = "Length";
			// TrackObject_Length.Kind = null;
			TrackObject_Length.SetClassLazy(() => TrackObject);
			TrackObject_Length.DefaultValue = null;
			// TrackObject_Length.IsContainment = null;
			Vertex.Documentation = "";
			Vertex.Name = "Vertex";
			Vertex.SetNamespaceLazy(() => __tmp1);
			// Vertex.IsAbstract = null;
			Vertex.SuperClasses.AddLazy(() => Declaration);
			Vertex.Properties.AddLazy(() => Vertex_Kind);
			Vertex_Kind.SetTypeLazy(() => VertexKind);
			Vertex_Kind.Documentation = "";
			Vertex_Kind.Name = "Kind";
			// Vertex_Kind.Kind = null;
			Vertex_Kind.SetClassLazy(() => Vertex);
			Vertex_Kind.DefaultValue = null;
			// Vertex_Kind.IsContainment = null;
			Segment.Documentation = "";
			Segment.Name = "Segment";
			Segment.SetNamespaceLazy(() => __tmp1);
			// Segment.IsAbstract = null;
			Segment.SuperClasses.AddLazy(() => TrackObject);
			Segment.Properties.AddLazy(() => Segment_Start);
			Segment.Properties.AddLazy(() => Segment_End);
			Segment.Properties.AddLazy(() => Segment_Objects);
			Segment_Start.SetTypeLazy(() => Vertex);
			Segment_Start.Documentation = "";
			Segment_Start.Name = "Start";
			// Segment_Start.Kind = null;
			Segment_Start.SetClassLazy(() => Segment);
			Segment_Start.DefaultValue = null;
			// Segment_Start.IsContainment = null;
			Segment_End.SetTypeLazy(() => Vertex);
			Segment_End.Documentation = "";
			Segment_End.Name = "End";
			// Segment_End.Kind = null;
			Segment_End.SetClassLazy(() => Segment);
			Segment_End.DefaultValue = null;
			// Segment_End.IsContainment = null;
			Segment_Objects.SetTypeLazy(() => __tmp23);
			Segment_Objects.Documentation = "";
			Segment_Objects.Name = "Objects";
			// Segment_Objects.Kind = null;
			Segment_Objects.SetClassLazy(() => Segment);
			Segment_Objects.DefaultValue = null;
			Segment_Objects.IsContainment = true;
			SegmentObject.Documentation = "";
			SegmentObject.Name = "SegmentObject";
			SegmentObject.SetNamespaceLazy(() => __tmp1);
			// SegmentObject.IsAbstract = null;
			SegmentObject.SuperClasses.AddLazy(() => NamedElement);
			SegmentObject.SuperClasses.AddLazy(() => RouteObject);
			SegmentObject.Properties.AddLazy(() => SegmentObject_Position);
			SegmentObject_Position.SetTypeLazy(() => SegmentPosition);
			SegmentObject_Position.Documentation = "";
			SegmentObject_Position.Name = "Position";
			// SegmentObject_Position.Kind = null;
			SegmentObject_Position.SetClassLazy(() => SegmentObject);
			SegmentObject_Position.DefaultValue = null;
			SegmentObject_Position.IsContainment = true;
			Derailer.Documentation = "";
			Derailer.Name = "Derailer";
			Derailer.SetNamespaceLazy(() => __tmp1);
			// Derailer.IsAbstract = null;
			Derailer.SuperClasses.AddLazy(() => SegmentObject);
			Derailer.Properties.AddLazy(() => Derailer_Active);
			Derailer_Active.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			Derailer_Active.Documentation = "";
			Derailer_Active.Name = "Active";
			// Derailer_Active.Kind = null;
			Derailer_Active.SetClassLazy(() => Derailer);
			Derailer_Active.DefaultValue = null;
			// Derailer_Active.IsContainment = null;
			LevelCrossing.Documentation = "";
			LevelCrossing.Name = "LevelCrossing";
			LevelCrossing.SetNamespaceLazy(() => __tmp1);
			// LevelCrossing.IsAbstract = null;
			LevelCrossing.SuperClasses.AddLazy(() => SegmentObject);
			LevelCrossing.Properties.AddLazy(() => LevelCrossing_Closed);
			LevelCrossing.Properties.AddLazy(() => LevelCrossing_Length);
			LevelCrossing_Closed.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			LevelCrossing_Closed.Documentation = "";
			LevelCrossing_Closed.Name = "Closed";
			// LevelCrossing_Closed.Kind = null;
			LevelCrossing_Closed.SetClassLazy(() => LevelCrossing);
			LevelCrossing_Closed.DefaultValue = null;
			// LevelCrossing_Closed.IsContainment = null;
			LevelCrossing_Length.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			LevelCrossing_Length.Documentation = "";
			LevelCrossing_Length.Name = "Length";
			// LevelCrossing_Length.Kind = null;
			LevelCrossing_Length.SetClassLazy(() => LevelCrossing);
			LevelCrossing_Length.DefaultValue = null;
			// LevelCrossing_Length.IsContainment = null;
			Signal.Documentation = "";
			Signal.Name = "Signal";
			Signal.SetNamespaceLazy(() => __tmp1);
			// Signal.IsAbstract = null;
			Signal.SuperClasses.AddLazy(() => SegmentObject);
			Signal.Properties.AddLazy(() => Signal_DistantFor);
			Signal.Properties.AddLazy(() => Signal_Main);
			Signal.Properties.AddLazy(() => Signal_Shunting);
			Signal_DistantFor.SetTypeLazy(() => Signal);
			Signal_DistantFor.Documentation = "";
			Signal_DistantFor.Name = "DistantFor";
			// Signal_DistantFor.Kind = null;
			Signal_DistantFor.SetClassLazy(() => Signal);
			Signal_DistantFor.DefaultValue = null;
			// Signal_DistantFor.IsContainment = null;
			Signal_Main.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			Signal_Main.Documentation = "";
			Signal_Main.Name = "Main";
			// Signal_Main.Kind = null;
			Signal_Main.SetClassLazy(() => Signal);
			Signal_Main.DefaultValue = null;
			// Signal_Main.IsContainment = null;
			Signal_Shunting.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			Signal_Shunting.Documentation = "";
			Signal_Shunting.Name = "Shunting";
			// Signal_Shunting.Kind = null;
			Signal_Shunting.SetClassLazy(() => Signal);
			Signal_Shunting.DefaultValue = null;
			// Signal_Shunting.IsContainment = null;
			Platform.Documentation = "";
			Platform.Name = "Platform";
			Platform.SetNamespaceLazy(() => __tmp1);
			// Platform.IsAbstract = null;
			Platform.SuperClasses.AddLazy(() => SegmentObject);
			Platform.Properties.AddLazy(() => Platform_Length);
			Platform_Length.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			Platform_Length.Documentation = "";
			Platform_Length.Name = "Length";
			// Platform_Length.Kind = null;
			Platform_Length.SetClassLazy(() => Platform);
			Platform_Length.DefaultValue = null;
			// Platform_Length.IsContainment = null;
			SegmentPosition.Documentation = "";
			SegmentPosition.Name = "SegmentPosition";
			SegmentPosition.SetNamespaceLazy(() => __tmp1);
			// SegmentPosition.IsAbstract = null;
			SegmentPosition.Properties.AddLazy(() => SegmentPosition_AtStart);
			SegmentPosition.Properties.AddLazy(() => SegmentPosition_AtEnd);
			SegmentPosition.Properties.AddLazy(() => SegmentPosition_Position);
			SegmentPosition.Properties.AddLazy(() => SegmentPosition_Side);
			SegmentPosition.Properties.AddLazy(() => SegmentPosition_Orientation);
			SegmentPosition.Properties.AddLazy(() => SegmentPosition_Segment);
			SegmentPosition_AtStart.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			SegmentPosition_AtStart.Documentation = "";
			SegmentPosition_AtStart.Name = "AtStart";
			// SegmentPosition_AtStart.Kind = null;
			SegmentPosition_AtStart.SetClassLazy(() => SegmentPosition);
			SegmentPosition_AtStart.DefaultValue = null;
			// SegmentPosition_AtStart.IsContainment = null;
			SegmentPosition_AtEnd.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			SegmentPosition_AtEnd.Documentation = "";
			SegmentPosition_AtEnd.Name = "AtEnd";
			// SegmentPosition_AtEnd.Kind = null;
			SegmentPosition_AtEnd.SetClassLazy(() => SegmentPosition);
			SegmentPosition_AtEnd.DefaultValue = null;
			// SegmentPosition_AtEnd.IsContainment = null;
			SegmentPosition_Position.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			SegmentPosition_Position.Documentation = "";
			SegmentPosition_Position.Name = "Position";
			// SegmentPosition_Position.Kind = null;
			SegmentPosition_Position.SetClassLazy(() => SegmentPosition);
			SegmentPosition_Position.DefaultValue = null;
			// SegmentPosition_Position.IsContainment = null;
			SegmentPosition_Side.SetTypeLazy(() => Side);
			SegmentPosition_Side.Documentation = "";
			SegmentPosition_Side.Name = "Side";
			// SegmentPosition_Side.Kind = null;
			SegmentPosition_Side.SetClassLazy(() => SegmentPosition);
			SegmentPosition_Side.DefaultValue = null;
			// SegmentPosition_Side.IsContainment = null;
			SegmentPosition_Orientation.SetTypeLazy(() => Orientation);
			SegmentPosition_Orientation.Documentation = "";
			SegmentPosition_Orientation.Name = "Orientation";
			// SegmentPosition_Orientation.Kind = null;
			SegmentPosition_Orientation.SetClassLazy(() => SegmentPosition);
			SegmentPosition_Orientation.DefaultValue = null;
			// SegmentPosition_Orientation.IsContainment = null;
			SegmentPosition_Segment.SetTypeLazy(() => Segment);
			SegmentPosition_Segment.Documentation = "";
			SegmentPosition_Segment.Name = "Segment";
			// SegmentPosition_Segment.Kind = null;
			SegmentPosition_Segment.SetClassLazy(() => SegmentPosition);
			SegmentPosition_Segment.DefaultValue = null;
			// SegmentPosition_Segment.IsContainment = null;
			Point.Documentation = "";
			Point.Name = "Point";
			Point.SetNamespaceLazy(() => __tmp1);
			// Point.IsAbstract = null;
			Point.SuperClasses.AddLazy(() => TrackObject);
			Point.Properties.AddLazy(() => Point_Inputs);
			Point.Properties.AddLazy(() => Point_Outputs);
			Point.Properties.AddLazy(() => Point_Kind);
			Point.Properties.AddLazy(() => Point_SelectedInput);
			Point.Properties.AddLazy(() => Point_SelectedOutput);
			Point.Properties.AddLazy(() => Point_Locked);
			Point_Inputs.SetTypeLazy(() => __tmp29);
			Point_Inputs.Documentation = "";
			Point_Inputs.Name = "Inputs";
			// Point_Inputs.Kind = null;
			Point_Inputs.SetClassLazy(() => Point);
			Point_Inputs.DefaultValue = null;
			// Point_Inputs.IsContainment = null;
			Point_Outputs.SetTypeLazy(() => __tmp26);
			Point_Outputs.Documentation = "";
			Point_Outputs.Name = "Outputs";
			// Point_Outputs.Kind = null;
			Point_Outputs.SetClassLazy(() => Point);
			Point_Outputs.DefaultValue = null;
			// Point_Outputs.IsContainment = null;
			Point_Kind.SetTypeLazy(() => PointKind);
			Point_Kind.Documentation = "";
			Point_Kind.Name = "Kind";
			// Point_Kind.Kind = null;
			Point_Kind.SetClassLazy(() => Point);
			Point_Kind.DefaultValue = null;
			// Point_Kind.IsContainment = null;
			Point_SelectedInput.SetTypeLazy(() => global::.MetaInstance.Int.ToMutable());
			Point_SelectedInput.Documentation = "";
			Point_SelectedInput.Name = "SelectedInput";
			// Point_SelectedInput.Kind = null;
			Point_SelectedInput.SetClassLazy(() => Point);
			Point_SelectedInput.DefaultValue = null;
			// Point_SelectedInput.IsContainment = null;
			Point_SelectedOutput.SetTypeLazy(() => global::.MetaInstance.Int.ToMutable());
			Point_SelectedOutput.Documentation = "";
			Point_SelectedOutput.Name = "SelectedOutput";
			// Point_SelectedOutput.Kind = null;
			Point_SelectedOutput.SetClassLazy(() => Point);
			Point_SelectedOutput.DefaultValue = null;
			// Point_SelectedOutput.IsContainment = null;
			Point_Locked.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			Point_Locked.Documentation = "";
			Point_Locked.Name = "Locked";
			// Point_Locked.Kind = null;
			Point_Locked.SetClassLazy(() => Point);
			Point_Locked.DefaultValue = null;
			// Point_Locked.IsContainment = null;
			Track.Documentation = "";
			Track.Name = "Track";
			Track.SetNamespaceLazy(() => __tmp1);
			// Track.IsAbstract = null;
			Track.SuperClasses.AddLazy(() => Declaration);
			Track.Properties.AddLazy(() => Track_Elements);
			Track_Elements.SetTypeLazy(() => __tmp25);
			Track_Elements.Documentation = "";
			Track_Elements.Name = "Elements";
			// Track_Elements.Kind = null;
			Track_Elements.SetClassLazy(() => Track);
			Track_Elements.DefaultValue = null;
			// Track_Elements.IsContainment = null;
			NamedElement.Documentation = "";
			NamedElement.Name = "NamedElement";
			NamedElement.SetNamespaceLazy(() => __tmp1);
			// NamedElement.IsAbstract = null;
			NamedElement.Properties.AddLazy(() => NamedElement_Name);
			NamedElement_Name.SetTypeLazy(() => global::.MetaInstance.String.ToMutable());
			NamedElement_Name.Documentation = "";
			NamedElement_Name.Name = "Name";
			// NamedElement_Name.Kind = null;
			NamedElement_Name.SetClassLazy(() => NamedElement);
			NamedElement_Name.DefaultValue = null;
			// NamedElement_Name.IsContainment = null;
			Train.Documentation = "";
			Train.Name = "Train";
			Train.SetNamespaceLazy(() => __tmp1);
			// Train.IsAbstract = null;
			Train.SuperClasses.AddLazy(() => Declaration);
			Train.Properties.AddLazy(() => Train_Length);
			Train.Properties.AddLazy(() => Train_Speed);
			Train.Properties.AddLazy(() => Train_Segments);
			Train.Properties.AddLazy(() => Train_Position);
			Train.Properties.AddLazy(() => Train_Acceleration);
			Train_Length.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			Train_Length.Documentation = "";
			Train_Length.Name = "Length";
			// Train_Length.Kind = null;
			Train_Length.SetClassLazy(() => Train);
			Train_Length.DefaultValue = null;
			// Train_Length.IsContainment = null;
			Train_Speed.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			Train_Speed.Documentation = "";
			Train_Speed.Name = "Speed";
			// Train_Speed.Kind = null;
			Train_Speed.SetClassLazy(() => Train);
			Train_Speed.DefaultValue = null;
			// Train_Speed.IsContainment = null;
			Train_Segments.SetTypeLazy(() => __tmp27);
			Train_Segments.Documentation = "";
			Train_Segments.Name = "Segments";
			// Train_Segments.Kind = null;
			Train_Segments.SetClassLazy(() => Train);
			Train_Segments.DefaultValue = null;
			Train_Segments.IsContainment = true;
			Train_Position.SetTypeLazy(() => SegmentPosition);
			Train_Position.Documentation = "";
			Train_Position.Name = "Position";
			// Train_Position.Kind = null;
			Train_Position.SetClassLazy(() => Train);
			Train_Position.DefaultValue = null;
			// Train_Position.IsContainment = null;
			Train_Acceleration.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			Train_Acceleration.Documentation = "";
			Train_Acceleration.Name = "Acceleration";
			// Train_Acceleration.Kind = null;
			Train_Acceleration.SetClassLazy(() => Train);
			Train_Acceleration.DefaultValue = null;
			// Train_Acceleration.IsContainment = null;
			TrainSegment.Documentation = "";
			TrainSegment.Name = "TrainSegment";
			TrainSegment.SetNamespaceLazy(() => __tmp1);
			// TrainSegment.IsAbstract = null;
			TrainSegment.Properties.AddLazy(() => TrainSegment_Position);
			TrainSegment.Properties.AddLazy(() => TrainSegment_Length);
			TrainSegment_Position.SetTypeLazy(() => SegmentPosition);
			TrainSegment_Position.Documentation = "";
			TrainSegment_Position.Name = "Position";
			// TrainSegment_Position.Kind = null;
			TrainSegment_Position.SetClassLazy(() => TrainSegment);
			TrainSegment_Position.DefaultValue = null;
			// TrainSegment_Position.IsContainment = null;
			TrainSegment_Length.SetTypeLazy(() => global::.MetaInstance.Double.ToMutable());
			TrainSegment_Length.Documentation = "";
			TrainSegment_Length.Name = "Length";
			// TrainSegment_Length.Kind = null;
			TrainSegment_Length.SetClassLazy(() => TrainSegment);
			TrainSegment_Length.DefaultValue = null;
			// TrainSegment_Length.IsContainment = null;
			RouteObject.Documentation = "";
			RouteObject.Name = "RouteObject";
			RouteObject.SetNamespaceLazy(() => __tmp1);
			// RouteObject.IsAbstract = null;
			RouteObject.Properties.AddLazy(() => RouteObject_SpeedLimit);
			RouteObject.Properties.AddLazy(() => RouteObject_Error);
			RouteObject_SpeedLimit.SetTypeLazy(() => SpeedLimit);
			RouteObject_SpeedLimit.Documentation = "";
			RouteObject_SpeedLimit.Name = "SpeedLimit";
			// RouteObject_SpeedLimit.Kind = null;
			RouteObject_SpeedLimit.SetClassLazy(() => RouteObject);
			RouteObject_SpeedLimit.DefaultValue = "SpeedLimit.Max";
			// RouteObject_SpeedLimit.IsContainment = null;
			RouteObject_Error.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			RouteObject_Error.Documentation = "";
			RouteObject_Error.Name = "Error";
			// RouteObject_Error.Kind = null;
			RouteObject_Error.SetClassLazy(() => RouteObject);
			RouteObject_Error.DefaultValue = null;
			// RouteObject_Error.IsContainment = null;
			TrainRoute.Documentation = "";
			TrainRoute.Name = "TrainRoute";
			TrainRoute.SetNamespaceLazy(() => __tmp1);
			// TrainRoute.IsAbstract = null;
			TrainRoute.SuperClasses.AddLazy(() => Declaration);
			TrainRoute.Properties.AddLazy(() => TrainRoute_Path);
			TrainRoute.Properties.AddLazy(() => TrainRoute_Kind);
			TrainRoute.Properties.AddLazy(() => TrainRoute_StartSignal);
			TrainRoute.Properties.AddLazy(() => TrainRoute_EndSignal);
			TrainRoute.Properties.AddLazy(() => TrainRoute_ProtectionObjects);
			TrainRoute.Properties.AddLazy(() => TrainRoute_ConflictingRoutes);
			TrainRoute.Properties.AddLazy(() => TrainRoute_Locked);
			TrainRoute_Path.SetTypeLazy(() => __tmp31);
			TrainRoute_Path.Documentation = "";
			TrainRoute_Path.Name = "Path";
			// TrainRoute_Path.Kind = null;
			TrainRoute_Path.SetClassLazy(() => TrainRoute);
			TrainRoute_Path.DefaultValue = null;
			TrainRoute_Path.IsContainment = true;
			TrainRoute_Kind.SetTypeLazy(() => TrainRouteKind);
			TrainRoute_Kind.Documentation = "";
			TrainRoute_Kind.Name = "Kind";
			// TrainRoute_Kind.Kind = null;
			TrainRoute_Kind.SetClassLazy(() => TrainRoute);
			TrainRoute_Kind.DefaultValue = null;
			// TrainRoute_Kind.IsContainment = null;
			TrainRoute_StartSignal.SetTypeLazy(() => Signal);
			TrainRoute_StartSignal.Documentation = "";
			TrainRoute_StartSignal.Name = "StartSignal";
			// TrainRoute_StartSignal.Kind = null;
			TrainRoute_StartSignal.SetClassLazy(() => TrainRoute);
			TrainRoute_StartSignal.DefaultValue = null;
			// TrainRoute_StartSignal.IsContainment = null;
			TrainRoute_EndSignal.SetTypeLazy(() => Signal);
			TrainRoute_EndSignal.Documentation = "";
			TrainRoute_EndSignal.Name = "EndSignal";
			// TrainRoute_EndSignal.Kind = null;
			TrainRoute_EndSignal.SetClassLazy(() => TrainRoute);
			TrainRoute_EndSignal.DefaultValue = null;
			// TrainRoute_EndSignal.IsContainment = null;
			TrainRoute_ProtectionObjects.SetTypeLazy(() => __tmp28);
			TrainRoute_ProtectionObjects.Documentation = "";
			TrainRoute_ProtectionObjects.Name = "ProtectionObjects";
			// TrainRoute_ProtectionObjects.Kind = null;
			TrainRoute_ProtectionObjects.SetClassLazy(() => TrainRoute);
			TrainRoute_ProtectionObjects.DefaultValue = null;
			TrainRoute_ProtectionObjects.IsContainment = true;
			TrainRoute_ConflictingRoutes.SetTypeLazy(() => __tmp30);
			TrainRoute_ConflictingRoutes.Documentation = "";
			TrainRoute_ConflictingRoutes.Name = "ConflictingRoutes";
			// TrainRoute_ConflictingRoutes.Kind = null;
			TrainRoute_ConflictingRoutes.SetClassLazy(() => TrainRoute);
			TrainRoute_ConflictingRoutes.DefaultValue = null;
			// TrainRoute_ConflictingRoutes.IsContainment = null;
			TrainRoute_Locked.SetTypeLazy(() => global::.MetaInstance.Bool.ToMutable());
			TrainRoute_Locked.Documentation = "";
			TrainRoute_Locked.Name = "Locked";
			// TrainRoute_Locked.Kind = null;
			TrainRoute_Locked.SetClassLazy(() => TrainRoute);
			TrainRoute_Locked.DefaultValue = null;
			// TrainRoute_Locked.IsContainment = null;
			TrainRouteObject.Documentation = "";
			TrainRouteObject.Name = "TrainRouteObject";
			TrainRouteObject.SetNamespaceLazy(() => __tmp1);
			// TrainRouteObject.IsAbstract = null;
			TrainRouteObject.Properties.AddLazy(() => TrainRouteObject_SpeedLimit);
			TrainRouteObject_SpeedLimit.SetTypeLazy(() => SpeedLimit);
			TrainRouteObject_SpeedLimit.Documentation = "";
			TrainRouteObject_SpeedLimit.Name = "SpeedLimit";
			// TrainRouteObject_SpeedLimit.Kind = null;
			TrainRouteObject_SpeedLimit.SetClassLazy(() => TrainRouteObject);
			TrainRouteObject_SpeedLimit.DefaultValue = null;
			// TrainRouteObject_SpeedLimit.IsContainment = null;
			TrainRoutePoint.Documentation = "";
			TrainRoutePoint.Name = "TrainRoutePoint";
			TrainRoutePoint.SetNamespaceLazy(() => __tmp1);
			// TrainRoutePoint.IsAbstract = null;
			TrainRoutePoint.SuperClasses.AddLazy(() => TrainRouteObject);
			TrainRoutePoint.Properties.AddLazy(() => TrainRoutePoint_OriginalPoint);
			TrainRoutePoint.Properties.AddLazy(() => TrainRoutePoint_SelectedInput);
			TrainRoutePoint.Properties.AddLazy(() => TrainRoutePoint_SelectedOutput);
			TrainRoutePoint_OriginalPoint.SetTypeLazy(() => Point);
			TrainRoutePoint_OriginalPoint.Documentation = "";
			TrainRoutePoint_OriginalPoint.Name = "OriginalPoint";
			// TrainRoutePoint_OriginalPoint.Kind = null;
			TrainRoutePoint_OriginalPoint.SetClassLazy(() => TrainRoutePoint);
			TrainRoutePoint_OriginalPoint.DefaultValue = null;
			// TrainRoutePoint_OriginalPoint.IsContainment = null;
			TrainRoutePoint_SelectedInput.SetTypeLazy(() => global::.MetaInstance.Int.ToMutable());
			TrainRoutePoint_SelectedInput.Documentation = "";
			TrainRoutePoint_SelectedInput.Name = "SelectedInput";
			// TrainRoutePoint_SelectedInput.Kind = null;
			TrainRoutePoint_SelectedInput.SetClassLazy(() => TrainRoutePoint);
			TrainRoutePoint_SelectedInput.DefaultValue = null;
			// TrainRoutePoint_SelectedInput.IsContainment = null;
			TrainRoutePoint_SelectedOutput.SetTypeLazy(() => global::.MetaInstance.Int.ToMutable());
			TrainRoutePoint_SelectedOutput.Documentation = "";
			TrainRoutePoint_SelectedOutput.Name = "SelectedOutput";
			// TrainRoutePoint_SelectedOutput.Kind = null;
			TrainRoutePoint_SelectedOutput.SetClassLazy(() => TrainRoutePoint);
			TrainRoutePoint_SelectedOutput.DefaultValue = null;
			// TrainRoutePoint_SelectedOutput.IsContainment = null;
			TrainRouteSegment.Documentation = "";
			TrainRouteSegment.Name = "TrainRouteSegment";
			TrainRouteSegment.SetNamespaceLazy(() => __tmp1);
			// TrainRouteSegment.IsAbstract = null;
			TrainRouteSegment.SuperClasses.AddLazy(() => TrainRouteObject);
			TrainRouteSegment.Properties.AddLazy(() => TrainRouteSegment_OriginalSegment);
			TrainRouteSegment_OriginalSegment.SetTypeLazy(() => Segment);
			TrainRouteSegment_OriginalSegment.Documentation = "";
			TrainRouteSegment_OriginalSegment.Name = "OriginalSegment";
			// TrainRouteSegment_OriginalSegment.Kind = null;
			TrainRouteSegment_OriginalSegment.SetClassLazy(() => TrainRouteSegment);
			TrainRouteSegment_OriginalSegment.DefaultValue = null;
			// TrainRouteSegment_OriginalSegment.IsContainment = null;
			__tmp2.Documentation = "";
			__tmp2.Name = "RailDsl";
			__tmp2.Uri = "http://www.bme.hu/iit/vke/raildsl";
			__tmp2.Prefix = "railDsl";
			__tmp2.SetNamespaceLazy(() => __tmp1);
			__tmp23.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp23.SetInnerTypeLazy(() => SegmentObject);
			__tmp24.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp24.SetInnerTypeLazy(() => Declaration);
			__tmp25.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.MultiList;
			__tmp25.SetInnerTypeLazy(() => TrackObject);
			__tmp26.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp26.SetInnerTypeLazy(() => Vertex);
			__tmp27.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp27.SetInnerTypeLazy(() => TrainSegment);
			__tmp28.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp28.SetInnerTypeLazy(() => TrainRouteObject);
			__tmp29.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp29.SetInnerTypeLazy(() => Vertex);
			__tmp30.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp30.SetInnerTypeLazy(() => TrainRoute);
			__tmp31.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp31.SetInnerTypeLazy(() => TrainRouteObject);
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::RailDsl.RailDslImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class RailDslImplementationBase
	{
		/// <summary>
		/// Implements the constructor: RailDslBuilderInstance()
		/// </summary>
		internal virtual void RailDslBuilderInstance(RailDslBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: Station()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Station(StationBuilder _this)
		{
			this.CallStationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Station
		/// </summary>
		protected virtual void CallStationSuperConstructors(StationBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
		public virtual void Station_MValidate(StationBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Declaration()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Declaration(DeclarationBuilder _this)
		{
			this.CallDeclarationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Declaration
		/// </summary>
		protected virtual void CallDeclarationSuperConstructors(DeclarationBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
		public virtual void Declaration_MValidate(DeclarationBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: TrackObject()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		///     <li>RouteObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RouteObject</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void TrackObject(TrackObjectBuilder _this)
		{
			this.CallTrackObjectSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of TrackObject
		/// </summary>
		protected virtual void CallTrackObjectSuperConstructors(TrackObjectBuilder _this)
		{
			this.NamedElement(_this);
			this.RouteObject(_this);
			this.Declaration(_this);
		}
	
	
		public virtual void TrackObject_MValidate(TrackObjectBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Vertex()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Vertex(VertexBuilder _this)
		{
			this.CallVertexSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Vertex
		/// </summary>
		protected virtual void CallVertexSuperConstructors(VertexBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		public virtual void Vertex_MValidate(VertexBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Segment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TrackObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RouteObject</li>
		///     <li>Declaration</li>
		///     <li>TrackObject</li>
		/// </ul>
		public virtual void Segment(SegmentBuilder _this)
		{
			this.CallSegmentSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of Segment
		/// </summary>
		protected virtual void CallSegmentSuperConstructors(SegmentBuilder _this)
		{
			this.NamedElement(_this);
			this.RouteObject(_this);
			this.Declaration(_this);
			this.TrackObject(_this);
		}
	
	
		public virtual void Segment_MValidate(SegmentBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: SegmentObject()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RouteObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>RouteObject</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void SegmentObject(SegmentObjectBuilder _this)
		{
			this.CallSegmentObjectSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of SegmentObject
		/// </summary>
		protected virtual void CallSegmentObjectSuperConstructors(SegmentObjectBuilder _this)
		{
			this.RouteObject(_this);
			this.NamedElement(_this);
		}
	
	
		public virtual void SegmentObject_MValidate(SegmentObjectBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Derailer()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SegmentObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>RouteObject</li>
		///     <li>NamedElement</li>
		///     <li>SegmentObject</li>
		/// </ul>
		public virtual void Derailer(DerailerBuilder _this)
		{
			this.CallDerailerSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of Derailer
		/// </summary>
		protected virtual void CallDerailerSuperConstructors(DerailerBuilder _this)
		{
			this.RouteObject(_this);
			this.NamedElement(_this);
			this.SegmentObject(_this);
		}
	
	
		public virtual void Derailer_MValidate(DerailerBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: LevelCrossing()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SegmentObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>RouteObject</li>
		///     <li>NamedElement</li>
		///     <li>SegmentObject</li>
		/// </ul>
		public virtual void LevelCrossing(LevelCrossingBuilder _this)
		{
			this.CallLevelCrossingSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of LevelCrossing
		/// </summary>
		protected virtual void CallLevelCrossingSuperConstructors(LevelCrossingBuilder _this)
		{
			this.RouteObject(_this);
			this.NamedElement(_this);
			this.SegmentObject(_this);
		}
	
	
		public virtual void LevelCrossing_MValidate(LevelCrossingBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Signal()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SegmentObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>RouteObject</li>
		///     <li>NamedElement</li>
		///     <li>SegmentObject</li>
		/// </ul>
		public virtual void Signal(SignalBuilder _this)
		{
			this.CallSignalSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of Signal
		/// </summary>
		protected virtual void CallSignalSuperConstructors(SignalBuilder _this)
		{
			this.RouteObject(_this);
			this.NamedElement(_this);
			this.SegmentObject(_this);
		}
	
	
		public virtual void Signal_MValidate(SignalBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Platform()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SegmentObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>RouteObject</li>
		///     <li>NamedElement</li>
		///     <li>SegmentObject</li>
		/// </ul>
		public virtual void Platform(PlatformBuilder _this)
		{
			this.CallPlatformSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of Platform
		/// </summary>
		protected virtual void CallPlatformSuperConstructors(PlatformBuilder _this)
		{
			this.RouteObject(_this);
			this.NamedElement(_this);
			this.SegmentObject(_this);
		}
	
	
		public virtual void Platform_MValidate(PlatformBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: SegmentPosition()
		/// </summary>
		public virtual void SegmentPosition(SegmentPositionBuilder _this)
		{
			this.CallSegmentPositionSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of SegmentPosition
		/// </summary>
		protected virtual void CallSegmentPositionSuperConstructors(SegmentPositionBuilder _this)
		{
		}
	
	
		public virtual void SegmentPosition_MValidate(SegmentPositionBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Point()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TrackObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RouteObject</li>
		///     <li>Declaration</li>
		///     <li>TrackObject</li>
		/// </ul>
		public virtual void Point(PointBuilder _this)
		{
			this.CallPointSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of Point
		/// </summary>
		protected virtual void CallPointSuperConstructors(PointBuilder _this)
		{
			this.NamedElement(_this);
			this.RouteObject(_this);
			this.Declaration(_this);
			this.TrackObject(_this);
		}
	
	
		public virtual void Point_MValidate(PointBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Track()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Track(TrackBuilder _this)
		{
			this.CallTrackSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Track
		/// </summary>
		protected virtual void CallTrackSuperConstructors(TrackBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		public virtual void Track_MValidate(TrackBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: NamedElement()
		/// </summary>
		public virtual void NamedElement(NamedElementBuilder _this)
		{
			this.CallNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NamedElement
		/// </summary>
		protected virtual void CallNamedElementSuperConstructors(NamedElementBuilder _this)
		{
		}
	
	
		public virtual void NamedElement_MValidate(NamedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: Train()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Train(TrainBuilder _this)
		{
			this.CallTrainSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Train
		/// </summary>
		protected virtual void CallTrainSuperConstructors(TrainBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		public virtual void Train_MValidate(TrainBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: TrainSegment()
		/// </summary>
		public virtual void TrainSegment(TrainSegmentBuilder _this)
		{
			this.CallTrainSegmentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TrainSegment
		/// </summary>
		protected virtual void CallTrainSegmentSuperConstructors(TrainSegmentBuilder _this)
		{
		}
	
	
		public virtual void TrainSegment_MValidate(TrainSegmentBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: RouteObject()
		/// </summary>
		public virtual void RouteObject(RouteObjectBuilder _this)
		{
			this.CallRouteObjectSuperConstructors(_this);
			_this.SetSpeedLimitLazy(() => SpeedLimit.Max);
		}
	
		/// <summary>
		/// Calls the super constructors of RouteObject
		/// </summary>
		protected virtual void CallRouteObjectSuperConstructors(RouteObjectBuilder _this)
		{
		}
	
	
		public virtual void RouteObject_MValidate(RouteObjectBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: TrainRoute()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void TrainRoute(TrainRouteBuilder _this)
		{
			this.CallTrainRouteSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TrainRoute
		/// </summary>
		protected virtual void CallTrainRouteSuperConstructors(TrainRouteBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		public virtual void TrainRoute_MValidate(TrainRouteBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: TrainRouteObject()
		/// </summary>
		public virtual void TrainRouteObject(TrainRouteObjectBuilder _this)
		{
			this.CallTrainRouteObjectSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TrainRouteObject
		/// </summary>
		protected virtual void CallTrainRouteObjectSuperConstructors(TrainRouteObjectBuilder _this)
		{
		}
	
	
		public virtual void TrainRouteObject_MValidate(TrainRouteObjectBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: TrainRoutePoint()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TrainRouteObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>TrainRouteObject</li>
		/// </ul>
		public virtual void TrainRoutePoint(TrainRoutePointBuilder _this)
		{
			this.CallTrainRoutePointSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TrainRoutePoint
		/// </summary>
		protected virtual void CallTrainRoutePointSuperConstructors(TrainRoutePointBuilder _this)
		{
			this.TrainRouteObject(_this);
		}
	
	
		public virtual void TrainRoutePoint_MValidate(TrainRoutePointBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: TrainRouteSegment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TrainRouteObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>TrainRouteObject</li>
		/// </ul>
		public virtual void TrainRouteSegment(TrainRouteSegmentBuilder _this)
		{
			this.CallTrainRouteSegmentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TrainRouteSegment
		/// </summary>
		protected virtual void CallTrainRouteSegmentSuperConstructors(TrainRouteSegmentBuilder _this)
		{
			this.TrainRouteObject(_this);
		}
	
	
		public virtual void TrainRouteSegment_MValidate(TrainRouteSegmentBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
		}
	
	
	
	
	
	
	
	
	}

	internal class RailDslImplementationProvider
	{
		// If there is a compile error at this line, create a new class called RailDslImplementation
		// which is a subclass of global::RailDsl.RailDslImplementationBase:
		private static RailDslImplementation implementation = new RailDslImplementation();
	
		public static RailDslImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
