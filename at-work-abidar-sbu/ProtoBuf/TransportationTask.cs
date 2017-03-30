// Generated by ProtoGen, Version=2.4.1.555, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48.  DO NOT EDIT!
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace atwork_pb_msgs {
  
  namespace Proto {
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class TransportationTask {
    
      #region Extension registration
      public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
      }
      #endregion
      #region Static variables
      internal static pbd::MessageDescriptor internal__static_atwork_pb_msgs_TransportationTask__Descriptor;
      internal static pb::FieldAccess.FieldAccessorTable<global::atwork_pb_msgs.TransportationTask, global::atwork_pb_msgs.TransportationTask.Builder> internal__static_atwork_pb_msgs_TransportationTask__FieldAccessorTable;
      #endregion
      #region Descriptor
      public static pbd::FileDescriptor Descriptor {
        get { return descriptor; }
      }
      private static pbd::FileDescriptor descriptor;
      
      static TransportationTask() {
        byte[] descriptorData = global::System.Convert.FromBase64String(
            string.Concat(
              "ChhUcmFuc3BvcnRhdGlvblRhc2sucHJvdG8SDmF0d29ya19wYl9tc2dzGg9J", 
              "bnZlbnRvcnkucHJvdG8aClRpbWUucHJvdG8iuQIKElRyYW5zcG9ydGF0aW9u", 
              "VGFzaxIwCgZvYmplY3QYASACKAsyIC5hdHdvcmtfcGJfbXNncy5PYmplY3RJ", 
              "ZGVudGlmaWVyEjMKCWNvbnRhaW5lchgCIAEoCzIgLmF0d29ya19wYl9tc2dz", 
              "Lk9iamVjdElkZW50aWZpZXISGgoScXVhbnRpdHlfZGVsaXZlcmVkGAMgAigE", 
              "EhoKEnF1YW50aXR5X3JlcXVlc3RlZBgEIAEoBBI3CgtkZXN0aW5hdGlvbhgF", 
              "IAEoCzIiLmF0d29ya19wYl9tc2dzLkxvY2F0aW9uSWRlbnRpZmllchIyCgZz", 
              "b3VyY2UYBiABKAsyIi5hdHdvcmtfcGJfbXNncy5Mb2NhdGlvbklkZW50aWZp", 
              "ZXISFwoPcHJvY2Vzc2luZ190ZWFtGAcgASgJQjIKFm9yZy5hdHdvcmsuY29t", 
            "bW9uX21zZ3NCGFRyYW5zcG9ydGF0aW9uVGFza1Byb3Rvcw=="));
        pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
          descriptor = root;
          internal__static_atwork_pb_msgs_TransportationTask__Descriptor = Descriptor.MessageTypes[0];
          internal__static_atwork_pb_msgs_TransportationTask__FieldAccessorTable = 
              new pb::FieldAccess.FieldAccessorTable<global::atwork_pb_msgs.TransportationTask, global::atwork_pb_msgs.TransportationTask.Builder>(internal__static_atwork_pb_msgs_TransportationTask__Descriptor,
                  new string[] { "Object", "Container", "QuantityDelivered", "QuantityRequested", "Destination", "Source", "ProcessingTeam", });
          return null;
        };
        pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
            new pbd::FileDescriptor[] {
            global::atwork_pb_msgs.Proto.Inventory.Descriptor, 
            global::atwork_pb_msgs.Proto.Time.Descriptor, 
            }, assigner);
      }
      #endregion
      
    }
  }
  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class TransportationTask : pb::GeneratedMessage<TransportationTask, TransportationTask.Builder> {
    private TransportationTask() { }
    private static readonly TransportationTask defaultInstance = new TransportationTask().MakeReadOnly();
    private static readonly string[] _transportationTaskFieldNames = new string[] { "container", "destination", "object", "processing_team", "quantity_delivered", "quantity_requested", "source" };
    private static readonly uint[] _transportationTaskFieldTags = new uint[] { 18, 42, 10, 58, 24, 32, 50 };
    public static TransportationTask DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override TransportationTask DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override TransportationTask ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::atwork_pb_msgs.Proto.TransportationTask.internal__static_atwork_pb_msgs_TransportationTask__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<TransportationTask, TransportationTask.Builder> InternalFieldAccessors {
      get { return global::atwork_pb_msgs.Proto.TransportationTask.internal__static_atwork_pb_msgs_TransportationTask__FieldAccessorTable; }
    }
    
    public const int ObjectFieldNumber = 1;
    private bool hasObject;
    private global::atwork_pb_msgs.ObjectIdentifier object_;
    public bool HasObject {
      get { return hasObject; }
    }
    public global::atwork_pb_msgs.ObjectIdentifier Object {
      get { return object_ ?? global::atwork_pb_msgs.ObjectIdentifier.DefaultInstance; }
    }
    
    public const int ContainerFieldNumber = 2;
    private bool hasContainer;
    private global::atwork_pb_msgs.ObjectIdentifier container_;
    public bool HasContainer {
      get { return hasContainer; }
    }
    public global::atwork_pb_msgs.ObjectIdentifier Container {
      get { return container_ ?? global::atwork_pb_msgs.ObjectIdentifier.DefaultInstance; }
    }
    
    public const int QuantityDeliveredFieldNumber = 3;
    private bool hasQuantityDelivered;
    private ulong quantityDelivered_;
    public bool HasQuantityDelivered {
      get { return hasQuantityDelivered; }
    }
    [global::System.CLSCompliant(false)]
    public ulong QuantityDelivered {
      get { return quantityDelivered_; }
    }
    
    public const int QuantityRequestedFieldNumber = 4;
    private bool hasQuantityRequested;
    private ulong quantityRequested_;
    public bool HasQuantityRequested {
      get { return hasQuantityRequested; }
    }
    [global::System.CLSCompliant(false)]
    public ulong QuantityRequested {
      get { return quantityRequested_; }
    }
    
    public const int DestinationFieldNumber = 5;
    private bool hasDestination;
    private global::atwork_pb_msgs.LocationIdentifier destination_;
    public bool HasDestination {
      get { return hasDestination; }
    }
    public global::atwork_pb_msgs.LocationIdentifier Destination {
      get { return destination_ ?? global::atwork_pb_msgs.LocationIdentifier.DefaultInstance; }
    }
    
    public const int SourceFieldNumber = 6;
    private bool hasSource;
    private global::atwork_pb_msgs.LocationIdentifier source_;
    public bool HasSource {
      get { return hasSource; }
    }
    public global::atwork_pb_msgs.LocationIdentifier Source {
      get { return source_ ?? global::atwork_pb_msgs.LocationIdentifier.DefaultInstance; }
    }
    
    public const int ProcessingTeamFieldNumber = 7;
    private bool hasProcessingTeam;
    private string processingTeam_ = "";
    public bool HasProcessingTeam {
      get { return hasProcessingTeam; }
    }
    public string ProcessingTeam {
      get { return processingTeam_; }
    }
    
    public override bool IsInitialized {
      get {
        if (!hasObject) return false;
        if (!hasQuantityDelivered) return false;
        if (!Object.IsInitialized) return false;
        if (HasContainer) {
          if (!Container.IsInitialized) return false;
        }
        if (HasDestination) {
          if (!Destination.IsInitialized) return false;
        }
        if (HasSource) {
          if (!Source.IsInitialized) return false;
        }
        return true;
      }
    }
    
    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _transportationTaskFieldNames;
      if (hasObject) {
        output.WriteMessage(1, field_names[2], Object);
      }
      if (hasContainer) {
        output.WriteMessage(2, field_names[0], Container);
      }
      if (hasQuantityDelivered) {
        output.WriteUInt64(3, field_names[4], QuantityDelivered);
      }
      if (hasQuantityRequested) {
        output.WriteUInt64(4, field_names[5], QuantityRequested);
      }
      if (hasDestination) {
        output.WriteMessage(5, field_names[1], Destination);
      }
      if (hasSource) {
        output.WriteMessage(6, field_names[6], Source);
      }
      if (hasProcessingTeam) {
        output.WriteString(7, field_names[3], ProcessingTeam);
      }
      UnknownFields.WriteTo(output);
    }
    
    private int memoizedSerializedSize = -1;
    public override int SerializedSize {
      get {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        return CalcSerializedSize();
      }
    }
    
    private int CalcSerializedSize() {
      int size = memoizedSerializedSize;
      if (size != -1) return size;
      
      size = 0;
      if (hasObject) {
        size += pb::CodedOutputStream.ComputeMessageSize(1, Object);
      }
      if (hasContainer) {
        size += pb::CodedOutputStream.ComputeMessageSize(2, Container);
      }
      if (hasQuantityDelivered) {
        size += pb::CodedOutputStream.ComputeUInt64Size(3, QuantityDelivered);
      }
      if (hasQuantityRequested) {
        size += pb::CodedOutputStream.ComputeUInt64Size(4, QuantityRequested);
      }
      if (hasDestination) {
        size += pb::CodedOutputStream.ComputeMessageSize(5, Destination);
      }
      if (hasSource) {
        size += pb::CodedOutputStream.ComputeMessageSize(6, Source);
      }
      if (hasProcessingTeam) {
        size += pb::CodedOutputStream.ComputeStringSize(7, ProcessingTeam);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static TransportationTask ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static TransportationTask ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static TransportationTask ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static TransportationTask ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static TransportationTask ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static TransportationTask ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static TransportationTask ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static TransportationTask ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static TransportationTask ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static TransportationTask ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private TransportationTask MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(TransportationTask prototype) {
      return new Builder(prototype);
    }
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<TransportationTask, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(TransportationTask cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private TransportationTask result;
      
      private TransportationTask PrepareBuilder() {
        if (resultIsReadOnly) {
          TransportationTask original = result;
          result = new TransportationTask();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override TransportationTask MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::atwork_pb_msgs.TransportationTask.Descriptor; }
      }
      
      public override TransportationTask DefaultInstanceForType {
        get { return global::atwork_pb_msgs.TransportationTask.DefaultInstance; }
      }
      
      public override TransportationTask BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      public override Builder MergeFrom(pb::IMessage other) {
        if (other is TransportationTask) {
          return MergeFrom((TransportationTask) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }
      
      public override Builder MergeFrom(TransportationTask other) {
        if (other == global::atwork_pb_msgs.TransportationTask.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasObject) {
          MergeObject(other.Object);
        }
        if (other.HasContainer) {
          MergeContainer(other.Container);
        }
        if (other.HasQuantityDelivered) {
          QuantityDelivered = other.QuantityDelivered;
        }
        if (other.HasQuantityRequested) {
          QuantityRequested = other.QuantityRequested;
        }
        if (other.HasDestination) {
          MergeDestination(other.Destination);
        }
        if (other.HasSource) {
          MergeSource(other.Source);
        }
        if (other.HasProcessingTeam) {
          ProcessingTeam = other.ProcessingTeam;
        }
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input) {
        return MergeFrom(input, pb::ExtensionRegistry.Empty);
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        PrepareBuilder();
        pb::UnknownFieldSet.Builder unknownFields = null;
        uint tag;
        string field_name;
        while (input.ReadTag(out tag, out field_name)) {
          if(tag == 0 && field_name != null) {
            int field_ordinal = global::System.Array.BinarySearch(_transportationTaskFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _transportationTaskFieldTags[field_ordinal];
            else {
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              continue;
            }
          }
          switch (tag) {
            case 0: {
              throw pb::InvalidProtocolBufferException.InvalidTag();
            }
            default: {
              if (pb::WireFormat.IsEndGroupTag(tag)) {
                if (unknownFields != null) {
                  this.UnknownFields = unknownFields.Build();
                }
                return this;
              }
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              break;
            }
            case 10: {
              global::atwork_pb_msgs.ObjectIdentifier.Builder subBuilder = global::atwork_pb_msgs.ObjectIdentifier.CreateBuilder();
              if (result.hasObject) {
                subBuilder.MergeFrom(Object);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              Object = subBuilder.BuildPartial();
              break;
            }
            case 18: {
              global::atwork_pb_msgs.ObjectIdentifier.Builder subBuilder = global::atwork_pb_msgs.ObjectIdentifier.CreateBuilder();
              if (result.hasContainer) {
                subBuilder.MergeFrom(Container);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              Container = subBuilder.BuildPartial();
              break;
            }
            case 24: {
              result.hasQuantityDelivered = input.ReadUInt64(ref result.quantityDelivered_);
              break;
            }
            case 32: {
              result.hasQuantityRequested = input.ReadUInt64(ref result.quantityRequested_);
              break;
            }
            case 42: {
              global::atwork_pb_msgs.LocationIdentifier.Builder subBuilder = global::atwork_pb_msgs.LocationIdentifier.CreateBuilder();
              if (result.hasDestination) {
                subBuilder.MergeFrom(Destination);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              Destination = subBuilder.BuildPartial();
              break;
            }
            case 50: {
              global::atwork_pb_msgs.LocationIdentifier.Builder subBuilder = global::atwork_pb_msgs.LocationIdentifier.CreateBuilder();
              if (result.hasSource) {
                subBuilder.MergeFrom(Source);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              Source = subBuilder.BuildPartial();
              break;
            }
            case 58: {
              result.hasProcessingTeam = input.ReadString(ref result.processingTeam_);
              break;
            }
          }
        }
        
        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }
      
      
      public bool HasObject {
       get { return result.hasObject; }
      }
      public global::atwork_pb_msgs.ObjectIdentifier Object {
        get { return result.Object; }
        set { SetObject(value); }
      }
      public Builder SetObject(global::atwork_pb_msgs.ObjectIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasObject = true;
        result.object_ = value;
        return this;
      }
      public Builder SetObject(global::atwork_pb_msgs.ObjectIdentifier.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasObject = true;
        result.object_ = builderForValue.Build();
        return this;
      }
      public Builder MergeObject(global::atwork_pb_msgs.ObjectIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasObject &&
            result.object_ != global::atwork_pb_msgs.ObjectIdentifier.DefaultInstance) {
            result.object_ = global::atwork_pb_msgs.ObjectIdentifier.CreateBuilder(result.object_).MergeFrom(value).BuildPartial();
        } else {
          result.object_ = value;
        }
        result.hasObject = true;
        return this;
      }
      public Builder ClearObject() {
        PrepareBuilder();
        result.hasObject = false;
        result.object_ = null;
        return this;
      }
      
      public bool HasContainer {
       get { return result.hasContainer; }
      }
      public global::atwork_pb_msgs.ObjectIdentifier Container {
        get { return result.Container; }
        set { SetContainer(value); }
      }
      public Builder SetContainer(global::atwork_pb_msgs.ObjectIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasContainer = true;
        result.container_ = value;
        return this;
      }
      public Builder SetContainer(global::atwork_pb_msgs.ObjectIdentifier.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasContainer = true;
        result.container_ = builderForValue.Build();
        return this;
      }
      public Builder MergeContainer(global::atwork_pb_msgs.ObjectIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasContainer &&
            result.container_ != global::atwork_pb_msgs.ObjectIdentifier.DefaultInstance) {
            result.container_ = global::atwork_pb_msgs.ObjectIdentifier.CreateBuilder(result.container_).MergeFrom(value).BuildPartial();
        } else {
          result.container_ = value;
        }
        result.hasContainer = true;
        return this;
      }
      public Builder ClearContainer() {
        PrepareBuilder();
        result.hasContainer = false;
        result.container_ = null;
        return this;
      }
      
      public bool HasQuantityDelivered {
        get { return result.hasQuantityDelivered; }
      }
      [global::System.CLSCompliant(false)]
      public ulong QuantityDelivered {
        get { return result.QuantityDelivered; }
        set { SetQuantityDelivered(value); }
      }
      [global::System.CLSCompliant(false)]
      public Builder SetQuantityDelivered(ulong value) {
        PrepareBuilder();
        result.hasQuantityDelivered = true;
        result.quantityDelivered_ = value;
        return this;
      }
      public Builder ClearQuantityDelivered() {
        PrepareBuilder();
        result.hasQuantityDelivered = false;
        result.quantityDelivered_ = 0UL;
        return this;
      }
      
      public bool HasQuantityRequested {
        get { return result.hasQuantityRequested; }
      }
      [global::System.CLSCompliant(false)]
      public ulong QuantityRequested {
        get { return result.QuantityRequested; }
        set { SetQuantityRequested(value); }
      }
      [global::System.CLSCompliant(false)]
      public Builder SetQuantityRequested(ulong value) {
        PrepareBuilder();
        result.hasQuantityRequested = true;
        result.quantityRequested_ = value;
        return this;
      }
      public Builder ClearQuantityRequested() {
        PrepareBuilder();
        result.hasQuantityRequested = false;
        result.quantityRequested_ = 0UL;
        return this;
      }
      
      public bool HasDestination {
       get { return result.hasDestination; }
      }
      public global::atwork_pb_msgs.LocationIdentifier Destination {
        get { return result.Destination; }
        set { SetDestination(value); }
      }
      public Builder SetDestination(global::atwork_pb_msgs.LocationIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasDestination = true;
        result.destination_ = value;
        return this;
      }
      public Builder SetDestination(global::atwork_pb_msgs.LocationIdentifier.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasDestination = true;
        result.destination_ = builderForValue.Build();
        return this;
      }
      public Builder MergeDestination(global::atwork_pb_msgs.LocationIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasDestination &&
            result.destination_ != global::atwork_pb_msgs.LocationIdentifier.DefaultInstance) {
            result.destination_ = global::atwork_pb_msgs.LocationIdentifier.CreateBuilder(result.destination_).MergeFrom(value).BuildPartial();
        } else {
          result.destination_ = value;
        }
        result.hasDestination = true;
        return this;
      }
      public Builder ClearDestination() {
        PrepareBuilder();
        result.hasDestination = false;
        result.destination_ = null;
        return this;
      }
      
      public bool HasSource {
       get { return result.hasSource; }
      }
      public global::atwork_pb_msgs.LocationIdentifier Source {
        get { return result.Source; }
        set { SetSource(value); }
      }
      public Builder SetSource(global::atwork_pb_msgs.LocationIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasSource = true;
        result.source_ = value;
        return this;
      }
      public Builder SetSource(global::atwork_pb_msgs.LocationIdentifier.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasSource = true;
        result.source_ = builderForValue.Build();
        return this;
      }
      public Builder MergeSource(global::atwork_pb_msgs.LocationIdentifier value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasSource &&
            result.source_ != global::atwork_pb_msgs.LocationIdentifier.DefaultInstance) {
            result.source_ = global::atwork_pb_msgs.LocationIdentifier.CreateBuilder(result.source_).MergeFrom(value).BuildPartial();
        } else {
          result.source_ = value;
        }
        result.hasSource = true;
        return this;
      }
      public Builder ClearSource() {
        PrepareBuilder();
        result.hasSource = false;
        result.source_ = null;
        return this;
      }
      
      public bool HasProcessingTeam {
        get { return result.hasProcessingTeam; }
      }
      public string ProcessingTeam {
        get { return result.ProcessingTeam; }
        set { SetProcessingTeam(value); }
      }
      public Builder SetProcessingTeam(string value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasProcessingTeam = true;
        result.processingTeam_ = value;
        return this;
      }
      public Builder ClearProcessingTeam() {
        PrepareBuilder();
        result.hasProcessingTeam = false;
        result.processingTeam_ = "";
        return this;
      }
    }
    static TransportationTask() {
      object.ReferenceEquals(global::atwork_pb_msgs.Proto.TransportationTask.Descriptor, null);
    }
  }
  
  #endregion
  
}

#endregion Designer generated code
