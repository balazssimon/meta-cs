namespace RailDsl
{
    metamodel RailDsl(Uri="http://www.bme.hu/iit/vke/raildsl",Prefix="railDsl"); 


    enum SpeedLimit
    {
        Stop,
        Speed40,
        Speed80,
        Speed120,
        Max
    }

    enum PointKind
    {
        FixedCrossing,
        SimplePoint,
        DoublePoint,
        SingleSlipPoint,
        DoubleSlipPoint
    }

    enum VertexKind
    {
        InnerVertex,
        TrackEnd,
        StationBorder
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

    enum TrainRouteKind
    {
        Main,
        Shunting
    }

    class Station : NamedElement
    {
    	containment list<Declaration> Declarations;
    }

    abstract class Declaration : NamedElement
    {
    }

    abstract class TrackObject : Declaration, RouteObject
    {
    	double Length;
    }

    class Vertex : Declaration
    {
    	VertexKind Kind;
    }

    class Segment : TrackObject
    {
    	Vertex Start;
    	Vertex End;
    	containment list<SegmentObject> Objects;
    }

    abstract class SegmentObject : NamedElement, RouteObject
    {
    	containment SegmentPosition Position;
    }

    class Derailer : SegmentObject
    {
    	bool Active;
    }

    class LevelCrossing : SegmentObject
    {
    	bool Closed;
    	double Length;
    }

    class Signal : SegmentObject
    {
    	Signal DistantFor;
    	bool Main;
    	bool Shunting;
    }

    class Platform : SegmentObject
    {
    	double Length;
    }

    class SegmentPosition
    {
    	bool AtStart;
    	bool AtEnd;
    	double Position;
    	Side Side;
    	Orientation Orientation;
    	Segment Segment;
    }

    class Point : TrackObject
    {
    	list<Vertex> Inputs;
    	list<Vertex> Outputs;
    	PointKind Kind;
    	int SelectedInput;
    	int SelectedOutput;
    	bool Locked;
    }

    class Track : Declaration
    {
    	multi_list<TrackObject> Elements;
    }

    abstract class NamedElement
    {
    	string Name;
    }

    class Train : Declaration
    {
    	double Length;
    	double Speed;
    	containment list<TrainSegment> Segments;
    	SegmentPosition Position;
    	double Acceleration;
    }

    class TrainSegment
    {
    	SegmentPosition Position;
    	double Length;
    }

    abstract class RouteObject
    {
    	SpeedLimit SpeedLimit = "SpeedLimit.Max";
    	bool Error;
    }

    class TrainRoute : Declaration
    {
    	containment list<TrainRouteObject> Path;
    	TrainRouteKind Kind;
    	Signal StartSignal;
    	Signal EndSignal;
    	containment list<TrainRouteObject> ProtectionObjects;
    	list<TrainRoute> ConflictingRoutes;
    	bool Locked;
    }

    class TrainRouteObject
    {
    	SpeedLimit SpeedLimit;
    }

    class TrainRoutePoint : TrainRouteObject
    {
    	Point OriginalPoint;
    	int SelectedInput;
    	int SelectedOutput;
    }

    class TrainRouteSegment : TrainRouteObject
    {
    	Segment OriginalSegment;
    }

}
