namespace RailDsl.Symbols
{
    metamodel RailDsl;

	enum VertexKind
	{
		InnerVertex,
		TrackEnd,
		StationBorder
	}

	enum TrainRouteKind
	{
		Main,
		Shunting
	}

	enum PointKind
	{
		FixedCrossing,
		SimplePoint,
		DoublePoint,
		SingleSlipPoint,
		DoubleSlipPoint
	}

	enum Orientation
	{
		Forwards,
		Backwards
	}

	enum Side
	{
		Both,
		Right,
		Left
	}

	enum SpeedLimit
	{
		Stop,
		Speed40,
		Speed80,
		Speed120,
		Max
	}

	abstract class NamedElement
	{
		[Name]
		string Name;
	}

	class Station
	{
		containment list<Declaration> Declarations;
	}

	abstract class Declaration
	{
	}

	abstract class RouteObject
	{
		SpeedLimit SpeedLimit;
		bool Error;
	}

	class Vertex : Declaration
	{
		VertexKind VertexKind;
	}

	class Track : Declaration
	{
		containment list<TrackObject> Elements;
	}

	abstract class TrackObject : Declaration, RouteObject
	{
		double Length;
	}

	class TrainRoute : Declaration
	{
		TrainRouteKind Kind;
		bool Locked;
		list<TrainRoute> ConflictingRoutes;
		Signal StartSignal;
		Signal EndSignal;
		containment list<TrainRouteObject> Path;
		containment list<TrainRouteObject> ProtectionObjects;
	}

	class Train : Declaration
	{
		double Length;
		double Speed;
		double Acceleration;
		SegmentPosition Position;
		containment list<TrainSegment> Segments;
	}

	class TrainSegment
	{
		SegmentPosition Position;
		double Length;
	}

	class Point : TrackObject
	{
		PointKind Kind;
		int SelectedInput;
		int SelectedOutput;
		bool Locked;
		list<Vertex> Inputs;
		list<Vertex> Outputs;
	}

	class Segment : TrackObject
	{
		Vertex Start;
		Vertex End;
		containment list<SegmentObject> Objects;
	}

	class TrainRouteObject
	{
		SpeedLimit SpeedLimit;
	}

	class TrainRoutePoint : TrainRouteObject
	{
		int SelectedInput;
		int SelectedOutput;
		Point OriginalPoint;
	}

	class TrainRouteSegment : TrainRouteObject
	{
		Segment OriginalSegment;
	}

	class SegmentPosition
	{
		bool AtStart;
		bool AtEnd;
		double Position;
		Side Side;
		Orientation Orientation;
	}

	abstract class SegmentObject : NamedElement, RouteObject
	{
		SegmentPosition Position;
	}

	class Signal : SegmentObject
	{
		bool Main;
		bool Shunting;
		Signal DistantFor;
	}

	class Platform : SegmentObject
	{
		double Length;
	}

	class LevelCrossing : SegmentObject
	{
		bool Closed;
		double Length;
	}

	class Derailer : SegmentObject
	{
		bool Active;
	}
}
