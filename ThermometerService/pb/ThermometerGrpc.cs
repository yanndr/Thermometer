// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: thermometer.proto
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace ThermometerService.Pb {
  /// <summary>
  /// The thermometer service definition.
  /// </summary>
  public static partial class Thermometer
  {
    static readonly string __ServiceName = "ThermometerService.pb.Thermometer";

    static readonly grpc::Marshaller<global::ThermometerService.Pb.TemperatureRequest> __Marshaller_TemperatureRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ThermometerService.Pb.TemperatureRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::ThermometerService.Pb.TemperatureReply> __Marshaller_TemperatureReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ThermometerService.Pb.TemperatureReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::ThermometerService.Pb.UpdateTemperatureRequest> __Marshaller_UpdateTemperatureRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ThermometerService.Pb.UpdateTemperatureRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::ThermometerService.Pb.UpdateTemperatureReply> __Marshaller_UpdateTemperatureReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ThermometerService.Pb.UpdateTemperatureReply.Parser.ParseFrom);

    static readonly grpc::Method<global::ThermometerService.Pb.TemperatureRequest, global::ThermometerService.Pb.TemperatureReply> __Method_GetTemperature = new grpc::Method<global::ThermometerService.Pb.TemperatureRequest, global::ThermometerService.Pb.TemperatureReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetTemperature",
        __Marshaller_TemperatureRequest,
        __Marshaller_TemperatureReply);

    static readonly grpc::Method<global::ThermometerService.Pb.UpdateTemperatureRequest, global::ThermometerService.Pb.UpdateTemperatureReply> __Method_UpdateTemperature = new grpc::Method<global::ThermometerService.Pb.UpdateTemperatureRequest, global::ThermometerService.Pb.UpdateTemperatureReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateTemperature",
        __Marshaller_UpdateTemperatureRequest,
        __Marshaller_UpdateTemperatureReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ThermometerService.Pb.ThermometerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Thermometer</summary>
    public abstract partial class ThermometerBase
    {
      public virtual global::System.Threading.Tasks.Task<global::ThermometerService.Pb.TemperatureReply> GetTemperature(global::ThermometerService.Pb.TemperatureRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::ThermometerService.Pb.UpdateTemperatureReply> UpdateTemperature(global::ThermometerService.Pb.UpdateTemperatureRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Thermometer</summary>
    public partial class ThermometerClient : grpc::ClientBase<ThermometerClient>
    {
      /// <summary>Creates a new client for Thermometer</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ThermometerClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Thermometer that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ThermometerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ThermometerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ThermometerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::ThermometerService.Pb.TemperatureReply GetTemperature(global::ThermometerService.Pb.TemperatureRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetTemperature(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ThermometerService.Pb.TemperatureReply GetTemperature(global::ThermometerService.Pb.TemperatureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetTemperature, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ThermometerService.Pb.TemperatureReply> GetTemperatureAsync(global::ThermometerService.Pb.TemperatureRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetTemperatureAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ThermometerService.Pb.TemperatureReply> GetTemperatureAsync(global::ThermometerService.Pb.TemperatureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetTemperature, null, options, request);
      }
      public virtual global::ThermometerService.Pb.UpdateTemperatureReply UpdateTemperature(global::ThermometerService.Pb.UpdateTemperatureRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UpdateTemperature(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ThermometerService.Pb.UpdateTemperatureReply UpdateTemperature(global::ThermometerService.Pb.UpdateTemperatureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateTemperature, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ThermometerService.Pb.UpdateTemperatureReply> UpdateTemperatureAsync(global::ThermometerService.Pb.UpdateTemperatureRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UpdateTemperatureAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ThermometerService.Pb.UpdateTemperatureReply> UpdateTemperatureAsync(global::ThermometerService.Pb.UpdateTemperatureRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateTemperature, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ThermometerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ThermometerClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ThermometerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetTemperature, serviceImpl.GetTemperature)
          .AddMethod(__Method_UpdateTemperature, serviceImpl.UpdateTemperature).Build();
    }

  }
}
#endregion