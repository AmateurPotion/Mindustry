// Decompiled with JetBrains decompiler
// Type: arc.Net
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public class Net : Object
  {
    private NetJavaImpl impl;

    [Signature("(Ljava/lang/String;Larc/func/Cons<Larc/Net$HttpResponse;>;Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [LineNumberTable(new byte[] {159, 185, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void httpGet(string url, Cons success, Cons failure) => this.http(new Net.HttpRequest().method(Net.HttpMethod.__\u003C\u003EGET).url(url), success, failure);

    [LineNumberTable(new byte[] {159, 164, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Net()
    {
      Net net = this;
      this.impl = new NetJavaImpl();
    }

    [Signature("(Larc/Net$HttpRequest;Larc/func/Cons<Larc/Net$HttpResponse;>;Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [LineNumberTable(new byte[] {159, 180, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void http(Net.HttpRequest httpRequest, Cons success, Cons failure) => this.impl.http(httpRequest, success, failure);

    [LineNumberTable(new byte[] {159, 136, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlock(bool block) => this.impl.setBlock(block);

    [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<Larc/Net$HttpResponse;>;Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [LineNumberTable(new byte[] {159, 190, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void httpPost(string url, string content, Cons success, Cons failure) => this.http(new Net.HttpRequest().method(Net.HttpMethod.__\u003C\u003EPOST).content(content).url(url), success, failure);

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/Net$HttpMethod;>;")]
    [Modifiers]
    [Serializable]
    public sealed class HttpMethod : Enum
    {
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003EGET;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003EPOST;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003EPUT;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003EDELETE;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003EHEAD;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003ECONNECT;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003EOPTIONS;
      [Modifiers]
      internal static Net.HttpMethod __\u003C\u003ETRACE;
      [Modifiers]
      private static Net.HttpMethod[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private HttpMethod([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.HttpMethod[] values() => (Net.HttpMethod[]) Net.HttpMethod.\u0024VALUES.Clone();

      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.HttpMethod valueOf(string name) => (Net.HttpMethod) Enum.valueOf((Class) ClassLiteral<Net.HttpMethod>.Value, name);

      [LineNumberTable(new byte[] {159, 118, 141, 63, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static HttpMethod()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.Net$HttpMethod"))
          return;
        Net.HttpMethod.__\u003C\u003EGET = new Net.HttpMethod(nameof (GET), 0);
        Net.HttpMethod.__\u003C\u003EPOST = new Net.HttpMethod(nameof (POST), 1);
        Net.HttpMethod.__\u003C\u003EPUT = new Net.HttpMethod(nameof (PUT), 2);
        Net.HttpMethod.__\u003C\u003EDELETE = new Net.HttpMethod(nameof (DELETE), 3);
        Net.HttpMethod.__\u003C\u003EHEAD = new Net.HttpMethod(nameof (HEAD), 4);
        Net.HttpMethod.__\u003C\u003ECONNECT = new Net.HttpMethod(nameof (CONNECT), 5);
        Net.HttpMethod.__\u003C\u003EOPTIONS = new Net.HttpMethod(nameof (OPTIONS), 6);
        Net.HttpMethod.__\u003C\u003ETRACE = new Net.HttpMethod(nameof (TRACE), 7);
        Net.HttpMethod.\u0024VALUES = new Net.HttpMethod[8]
        {
          Net.HttpMethod.__\u003C\u003EGET,
          Net.HttpMethod.__\u003C\u003EPOST,
          Net.HttpMethod.__\u003C\u003EPUT,
          Net.HttpMethod.__\u003C\u003EDELETE,
          Net.HttpMethod.__\u003C\u003EHEAD,
          Net.HttpMethod.__\u003C\u003ECONNECT,
          Net.HttpMethod.__\u003C\u003EOPTIONS,
          Net.HttpMethod.__\u003C\u003ETRACE
        };
      }

      [Modifiers]
      public static Net.HttpMethod GET
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003EGET;
      }

      [Modifiers]
      public static Net.HttpMethod POST
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003EPOST;
      }

      [Modifiers]
      public static Net.HttpMethod PUT
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003EPUT;
      }

      [Modifiers]
      public static Net.HttpMethod DELETE
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003EDELETE;
      }

      [Modifiers]
      public static Net.HttpMethod HEAD
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003EHEAD;
      }

      [Modifiers]
      public static Net.HttpMethod CONNECT
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003ECONNECT;
      }

      [Modifiers]
      public static Net.HttpMethod OPTIONS
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003EOPTIONS;
      }

      [Modifiers]
      public static Net.HttpMethod TRACE
      {
        [HideFromJava] get => Net.HttpMethod.__\u003C\u003ETRACE;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        GET,
        POST,
        PUT,
        DELETE,
        HEAD,
        CONNECT,
        OPTIONS,
        TRACE,
      }
    }

    public class HttpRequest : Object
    {
      public Net.HttpMethod method;
      public string url;
      [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;")]
      public ObjectMap headers;
      public int timeout;
      public string content;
      public InputStream contentStream;
      public long contentLength;
      public bool followRedirects;
      public bool includeCredentials;

      [LineNumberTable(new byte[] {77, 232, 43, 171, 235, 78, 135, 199})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public HttpRequest()
      {
        Net.HttpRequest httpRequest = this;
        this.headers = new ObjectMap();
        this.timeout = 2000;
        this.followRedirects = true;
        this.includeCredentials = false;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest method(Net.HttpMethod method)
      {
        this.method = method;
        return this;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest content(string content)
      {
        this.content = content;
        return this;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest url(string url)
      {
        this.url = url;
        return this;
      }

      [LineNumberTable(new byte[] {81, 232, 39, 171, 235, 78, 135, 231, 71, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public HttpRequest(Net.HttpMethod method)
      {
        Net.HttpRequest httpRequest = this;
        this.headers = new ObjectMap();
        this.timeout = 2000;
        this.followRedirects = true;
        this.includeCredentials = false;
        this.method = method;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest timeout(int timeout)
      {
        this.timeout = timeout;
        return this;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest redirects(bool followRedirects)
      {
        this.followRedirects = followRedirects;
        return this;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest credentials(bool includeCredentials)
      {
        this.includeCredentials = includeCredentials;
        return this;
      }

      [LineNumberTable(new byte[] {111, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest header(string name, string value)
      {
        this.headers.put((object) name, (object) value);
        return this;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpRequest content(InputStream contentStream, long contentLength)
      {
        this.contentStream = contentStream;
        this.contentLength = contentLength;
        return this;
      }
    }

    public interface HttpResponse
    {
      Net.HttpStatus getStatus();

      string getResultAsString();

      InputStream getResultAsStream();

      string getHeader(string str);

      byte[] getResult();

      [Signature("()Larc/struct/ObjectMap<Ljava/lang/String;Larc/struct/Seq<Ljava/lang/String;>;>;")]
      ObjectMap getHeaders();
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/Net$HttpStatus;>;")]
    [Modifiers]
    [Serializable]
    public sealed class HttpStatus : Enum
    {
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EUNKNOWN_STATUS;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ECONTINUE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ESWITCHING_PROTOCOLS;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EPROCESSING;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EOK;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ECREATED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EACCEPTED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ENON_AUTHORITATIVE_INFORMATION;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ENO_CONTENT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ERESET_CONTENT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EPARTIAL_CONTENT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EMULTI_STATUS;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EMULTIPLE_CHOICES;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EMOVED_PERMANENTLY;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EMOVED_TEMPORARILY;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ESEE_OTHER;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ENOT_MODIFIED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EUSE_PROXY;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ETEMPORARY_REDIRECT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EBAD_REQUEST;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EUNAUTHORIZED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EPAYMENT_REQUIRED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EFORBIDDEN;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ENOT_FOUND;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EMETHOD_NOT_ALLOWED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ENOT_ACCEPTABLE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EPROXY_AUTHENTICATION_REQUIRED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EREQUEST_TIMEOUT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ECONFLICT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EGONE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ELENGTH_REQUIRED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EPRECONDITION_FAILED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EREQUEST_TOO_LONG;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EREQUEST_URI_TOO_LONG;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EUNSUPPORTED_MEDIA_TYPE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EREQUESTED_RANGE_NOT_SATISFIABLE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EEXPECTATION_FAILED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EINSUFFICIENT_SPACE_ON_RESOURCE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EMETHOD_FAILURE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EUNPROCESSABLE_ENTITY;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ELOCKED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EFAILED_DEPENDENCY;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EINTERNAL_SERVER_ERROR;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ENOT_IMPLEMENTED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EBAD_GATEWAY;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003ESERVICE_UNAVAILABLE;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EGATEWAY_TIMEOUT;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EHTTP_VERSION_NOT_SUPPORTED;
      [Modifiers]
      internal static Net.HttpStatus __\u003C\u003EINSUFFICIENT_STORAGE;
      [Signature("Larc/struct/IntMap<Larc/Net$HttpStatus;>;")]
      private static IntMap byCode;
      internal int __\u003C\u003Ecode;
      [Modifiers]
      private static Net.HttpStatus[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(178)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.HttpStatus[] values() => (Net.HttpStatus[]) Net.HttpStatus.\u0024VALUES.Clone();

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {160, 126, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private HttpStatus([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        Net.HttpStatus httpStatus = this;
        this.__\u003C\u003Ecode = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(178)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.HttpStatus valueOf(string name) => (Net.HttpStatus) Enum.valueOf((Class) ClassLiteral<Net.HttpStatus>.Value, name);

      [LineNumberTable(new byte[] {160, 132, 103, 106, 115, 50, 198})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.HttpStatus byCode(int code)
      {
        if (Net.HttpStatus.byCode == null)
        {
          Net.HttpStatus.byCode = new IntMap();
          Net.HttpStatus[] httpStatusArray = Net.HttpStatus.values();
          int length = httpStatusArray.Length;
          for (int index = 0; index < length; ++index)
          {
            Net.HttpStatus httpStatus = httpStatusArray[index];
            Net.HttpStatus.byCode.put(httpStatus.__\u003C\u003Ecode, (object) httpStatus);
          }
        }
        return (Net.HttpStatus) Net.HttpStatus.byCode.get(code, (object) Net.HttpStatus.__\u003C\u003EUNKNOWN_STATUS);
      }

      [LineNumberTable(new byte[] {159, 98, 173, 145, 114, 114, 146, 117, 117, 149, 117, 117, 118, 118, 118, 118, 118, 150, 118, 118, 118, 118, 118, 118, 150, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 150, 118, 118, 118, 118, 150, 118, 118, 118, 246, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static HttpStatus()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.Net$HttpStatus"))
          return;
        Net.HttpStatus.__\u003C\u003EUNKNOWN_STATUS = new Net.HttpStatus(nameof (UNKNOWN_STATUS), 0, -1);
        Net.HttpStatus.__\u003C\u003ECONTINUE = new Net.HttpStatus(nameof (CONTINUE), 1, 100);
        Net.HttpStatus.__\u003C\u003ESWITCHING_PROTOCOLS = new Net.HttpStatus(nameof (SWITCHING_PROTOCOLS), 2, 101);
        Net.HttpStatus.__\u003C\u003EPROCESSING = new Net.HttpStatus(nameof (PROCESSING), 3, 102);
        Net.HttpStatus.__\u003C\u003EOK = new Net.HttpStatus(nameof (OK), 4, 200);
        Net.HttpStatus.__\u003C\u003ECREATED = new Net.HttpStatus(nameof (CREATED), 5, 201);
        Net.HttpStatus.__\u003C\u003EACCEPTED = new Net.HttpStatus(nameof (ACCEPTED), 6, 202);
        Net.HttpStatus.__\u003C\u003ENON_AUTHORITATIVE_INFORMATION = new Net.HttpStatus(nameof (NON_AUTHORITATIVE_INFORMATION), 7, 203);
        Net.HttpStatus.__\u003C\u003ENO_CONTENT = new Net.HttpStatus(nameof (NO_CONTENT), 8, 204);
        Net.HttpStatus.__\u003C\u003ERESET_CONTENT = new Net.HttpStatus(nameof (RESET_CONTENT), 9, 205);
        Net.HttpStatus.__\u003C\u003EPARTIAL_CONTENT = new Net.HttpStatus(nameof (PARTIAL_CONTENT), 10, 206);
        Net.HttpStatus.__\u003C\u003EMULTI_STATUS = new Net.HttpStatus(nameof (MULTI_STATUS), 11, 207);
        Net.HttpStatus.__\u003C\u003EMULTIPLE_CHOICES = new Net.HttpStatus(nameof (MULTIPLE_CHOICES), 12, 300);
        Net.HttpStatus.__\u003C\u003EMOVED_PERMANENTLY = new Net.HttpStatus(nameof (MOVED_PERMANENTLY), 13, 301);
        Net.HttpStatus.__\u003C\u003EMOVED_TEMPORARILY = new Net.HttpStatus(nameof (MOVED_TEMPORARILY), 14, 302);
        Net.HttpStatus.__\u003C\u003ESEE_OTHER = new Net.HttpStatus(nameof (SEE_OTHER), 15, 303);
        Net.HttpStatus.__\u003C\u003ENOT_MODIFIED = new Net.HttpStatus(nameof (NOT_MODIFIED), 16, 304);
        Net.HttpStatus.__\u003C\u003EUSE_PROXY = new Net.HttpStatus(nameof (USE_PROXY), 17, 305);
        Net.HttpStatus.__\u003C\u003ETEMPORARY_REDIRECT = new Net.HttpStatus(nameof (TEMPORARY_REDIRECT), 18, 307);
        Net.HttpStatus.__\u003C\u003EBAD_REQUEST = new Net.HttpStatus(nameof (BAD_REQUEST), 19, 400);
        Net.HttpStatus.__\u003C\u003EUNAUTHORIZED = new Net.HttpStatus(nameof (UNAUTHORIZED), 20, 401);
        Net.HttpStatus.__\u003C\u003EPAYMENT_REQUIRED = new Net.HttpStatus(nameof (PAYMENT_REQUIRED), 21, 402);
        Net.HttpStatus.__\u003C\u003EFORBIDDEN = new Net.HttpStatus(nameof (FORBIDDEN), 22, 403);
        Net.HttpStatus.__\u003C\u003ENOT_FOUND = new Net.HttpStatus(nameof (NOT_FOUND), 23, 404);
        Net.HttpStatus.__\u003C\u003EMETHOD_NOT_ALLOWED = new Net.HttpStatus(nameof (METHOD_NOT_ALLOWED), 24, 405);
        Net.HttpStatus.__\u003C\u003ENOT_ACCEPTABLE = new Net.HttpStatus(nameof (NOT_ACCEPTABLE), 25, 406);
        Net.HttpStatus.__\u003C\u003EPROXY_AUTHENTICATION_REQUIRED = new Net.HttpStatus(nameof (PROXY_AUTHENTICATION_REQUIRED), 26, 407);
        Net.HttpStatus.__\u003C\u003EREQUEST_TIMEOUT = new Net.HttpStatus(nameof (REQUEST_TIMEOUT), 27, 408);
        Net.HttpStatus.__\u003C\u003ECONFLICT = new Net.HttpStatus(nameof (CONFLICT), 28, 409);
        Net.HttpStatus.__\u003C\u003EGONE = new Net.HttpStatus(nameof (GONE), 29, 410);
        Net.HttpStatus.__\u003C\u003ELENGTH_REQUIRED = new Net.HttpStatus(nameof (LENGTH_REQUIRED), 30, 411);
        Net.HttpStatus.__\u003C\u003EPRECONDITION_FAILED = new Net.HttpStatus(nameof (PRECONDITION_FAILED), 31, 412);
        Net.HttpStatus.__\u003C\u003EREQUEST_TOO_LONG = new Net.HttpStatus(nameof (REQUEST_TOO_LONG), 32, 413);
        Net.HttpStatus.__\u003C\u003EREQUEST_URI_TOO_LONG = new Net.HttpStatus(nameof (REQUEST_URI_TOO_LONG), 33, 414);
        Net.HttpStatus.__\u003C\u003EUNSUPPORTED_MEDIA_TYPE = new Net.HttpStatus(nameof (UNSUPPORTED_MEDIA_TYPE), 34, 415);
        Net.HttpStatus.__\u003C\u003EREQUESTED_RANGE_NOT_SATISFIABLE = new Net.HttpStatus(nameof (REQUESTED_RANGE_NOT_SATISFIABLE), 35, 416);
        Net.HttpStatus.__\u003C\u003EEXPECTATION_FAILED = new Net.HttpStatus(nameof (EXPECTATION_FAILED), 36, 417);
        Net.HttpStatus.__\u003C\u003EINSUFFICIENT_SPACE_ON_RESOURCE = new Net.HttpStatus(nameof (INSUFFICIENT_SPACE_ON_RESOURCE), 37, 419);
        Net.HttpStatus.__\u003C\u003EMETHOD_FAILURE = new Net.HttpStatus(nameof (METHOD_FAILURE), 38, 420);
        Net.HttpStatus.__\u003C\u003EUNPROCESSABLE_ENTITY = new Net.HttpStatus(nameof (UNPROCESSABLE_ENTITY), 39, 422);
        Net.HttpStatus.__\u003C\u003ELOCKED = new Net.HttpStatus(nameof (LOCKED), 40, 423);
        Net.HttpStatus.__\u003C\u003EFAILED_DEPENDENCY = new Net.HttpStatus(nameof (FAILED_DEPENDENCY), 41, 424);
        Net.HttpStatus.__\u003C\u003EINTERNAL_SERVER_ERROR = new Net.HttpStatus(nameof (INTERNAL_SERVER_ERROR), 42, 500);
        Net.HttpStatus.__\u003C\u003ENOT_IMPLEMENTED = new Net.HttpStatus(nameof (NOT_IMPLEMENTED), 43, 501);
        Net.HttpStatus.__\u003C\u003EBAD_GATEWAY = new Net.HttpStatus(nameof (BAD_GATEWAY), 44, 502);
        Net.HttpStatus.__\u003C\u003ESERVICE_UNAVAILABLE = new Net.HttpStatus(nameof (SERVICE_UNAVAILABLE), 45, 503);
        Net.HttpStatus.__\u003C\u003EGATEWAY_TIMEOUT = new Net.HttpStatus(nameof (GATEWAY_TIMEOUT), 46, 504);
        Net.HttpStatus.__\u003C\u003EHTTP_VERSION_NOT_SUPPORTED = new Net.HttpStatus(nameof (HTTP_VERSION_NOT_SUPPORTED), 47, 505);
        Net.HttpStatus.__\u003C\u003EINSUFFICIENT_STORAGE = new Net.HttpStatus(nameof (INSUFFICIENT_STORAGE), 48, 507);
        Net.HttpStatus.\u0024VALUES = new Net.HttpStatus[49]
        {
          Net.HttpStatus.__\u003C\u003EUNKNOWN_STATUS,
          Net.HttpStatus.__\u003C\u003ECONTINUE,
          Net.HttpStatus.__\u003C\u003ESWITCHING_PROTOCOLS,
          Net.HttpStatus.__\u003C\u003EPROCESSING,
          Net.HttpStatus.__\u003C\u003EOK,
          Net.HttpStatus.__\u003C\u003ECREATED,
          Net.HttpStatus.__\u003C\u003EACCEPTED,
          Net.HttpStatus.__\u003C\u003ENON_AUTHORITATIVE_INFORMATION,
          Net.HttpStatus.__\u003C\u003ENO_CONTENT,
          Net.HttpStatus.__\u003C\u003ERESET_CONTENT,
          Net.HttpStatus.__\u003C\u003EPARTIAL_CONTENT,
          Net.HttpStatus.__\u003C\u003EMULTI_STATUS,
          Net.HttpStatus.__\u003C\u003EMULTIPLE_CHOICES,
          Net.HttpStatus.__\u003C\u003EMOVED_PERMANENTLY,
          Net.HttpStatus.__\u003C\u003EMOVED_TEMPORARILY,
          Net.HttpStatus.__\u003C\u003ESEE_OTHER,
          Net.HttpStatus.__\u003C\u003ENOT_MODIFIED,
          Net.HttpStatus.__\u003C\u003EUSE_PROXY,
          Net.HttpStatus.__\u003C\u003ETEMPORARY_REDIRECT,
          Net.HttpStatus.__\u003C\u003EBAD_REQUEST,
          Net.HttpStatus.__\u003C\u003EUNAUTHORIZED,
          Net.HttpStatus.__\u003C\u003EPAYMENT_REQUIRED,
          Net.HttpStatus.__\u003C\u003EFORBIDDEN,
          Net.HttpStatus.__\u003C\u003ENOT_FOUND,
          Net.HttpStatus.__\u003C\u003EMETHOD_NOT_ALLOWED,
          Net.HttpStatus.__\u003C\u003ENOT_ACCEPTABLE,
          Net.HttpStatus.__\u003C\u003EPROXY_AUTHENTICATION_REQUIRED,
          Net.HttpStatus.__\u003C\u003EREQUEST_TIMEOUT,
          Net.HttpStatus.__\u003C\u003ECONFLICT,
          Net.HttpStatus.__\u003C\u003EGONE,
          Net.HttpStatus.__\u003C\u003ELENGTH_REQUIRED,
          Net.HttpStatus.__\u003C\u003EPRECONDITION_FAILED,
          Net.HttpStatus.__\u003C\u003EREQUEST_TOO_LONG,
          Net.HttpStatus.__\u003C\u003EREQUEST_URI_TOO_LONG,
          Net.HttpStatus.__\u003C\u003EUNSUPPORTED_MEDIA_TYPE,
          Net.HttpStatus.__\u003C\u003EREQUESTED_RANGE_NOT_SATISFIABLE,
          Net.HttpStatus.__\u003C\u003EEXPECTATION_FAILED,
          Net.HttpStatus.__\u003C\u003EINSUFFICIENT_SPACE_ON_RESOURCE,
          Net.HttpStatus.__\u003C\u003EMETHOD_FAILURE,
          Net.HttpStatus.__\u003C\u003EUNPROCESSABLE_ENTITY,
          Net.HttpStatus.__\u003C\u003ELOCKED,
          Net.HttpStatus.__\u003C\u003EFAILED_DEPENDENCY,
          Net.HttpStatus.__\u003C\u003EINTERNAL_SERVER_ERROR,
          Net.HttpStatus.__\u003C\u003ENOT_IMPLEMENTED,
          Net.HttpStatus.__\u003C\u003EBAD_GATEWAY,
          Net.HttpStatus.__\u003C\u003ESERVICE_UNAVAILABLE,
          Net.HttpStatus.__\u003C\u003EGATEWAY_TIMEOUT,
          Net.HttpStatus.__\u003C\u003EHTTP_VERSION_NOT_SUPPORTED,
          Net.HttpStatus.__\u003C\u003EINSUFFICIENT_STORAGE
        };
      }

      [Modifiers]
      public static Net.HttpStatus UNKNOWN_STATUS
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EUNKNOWN_STATUS;
      }

      [Modifiers]
      public static Net.HttpStatus CONTINUE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ECONTINUE;
      }

      [Modifiers]
      public static Net.HttpStatus SWITCHING_PROTOCOLS
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ESWITCHING_PROTOCOLS;
      }

      [Modifiers]
      public static Net.HttpStatus PROCESSING
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EPROCESSING;
      }

      [Modifiers]
      public static Net.HttpStatus OK
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EOK;
      }

      [Modifiers]
      public static Net.HttpStatus CREATED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ECREATED;
      }

      [Modifiers]
      public static Net.HttpStatus ACCEPTED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EACCEPTED;
      }

      [Modifiers]
      public static Net.HttpStatus NON_AUTHORITATIVE_INFORMATION
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ENON_AUTHORITATIVE_INFORMATION;
      }

      [Modifiers]
      public static Net.HttpStatus NO_CONTENT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ENO_CONTENT;
      }

      [Modifiers]
      public static Net.HttpStatus RESET_CONTENT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ERESET_CONTENT;
      }

      [Modifiers]
      public static Net.HttpStatus PARTIAL_CONTENT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EPARTIAL_CONTENT;
      }

      [Modifiers]
      public static Net.HttpStatus MULTI_STATUS
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EMULTI_STATUS;
      }

      [Modifiers]
      public static Net.HttpStatus MULTIPLE_CHOICES
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EMULTIPLE_CHOICES;
      }

      [Modifiers]
      public static Net.HttpStatus MOVED_PERMANENTLY
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EMOVED_PERMANENTLY;
      }

      [Modifiers]
      public static Net.HttpStatus MOVED_TEMPORARILY
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EMOVED_TEMPORARILY;
      }

      [Modifiers]
      public static Net.HttpStatus SEE_OTHER
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ESEE_OTHER;
      }

      [Modifiers]
      public static Net.HttpStatus NOT_MODIFIED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ENOT_MODIFIED;
      }

      [Modifiers]
      public static Net.HttpStatus USE_PROXY
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EUSE_PROXY;
      }

      [Modifiers]
      public static Net.HttpStatus TEMPORARY_REDIRECT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ETEMPORARY_REDIRECT;
      }

      [Modifiers]
      public static Net.HttpStatus BAD_REQUEST
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EBAD_REQUEST;
      }

      [Modifiers]
      public static Net.HttpStatus UNAUTHORIZED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EUNAUTHORIZED;
      }

      [Modifiers]
      public static Net.HttpStatus PAYMENT_REQUIRED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EPAYMENT_REQUIRED;
      }

      [Modifiers]
      public static Net.HttpStatus FORBIDDEN
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EFORBIDDEN;
      }

      [Modifiers]
      public static Net.HttpStatus NOT_FOUND
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ENOT_FOUND;
      }

      [Modifiers]
      public static Net.HttpStatus METHOD_NOT_ALLOWED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EMETHOD_NOT_ALLOWED;
      }

      [Modifiers]
      public static Net.HttpStatus NOT_ACCEPTABLE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ENOT_ACCEPTABLE;
      }

      [Modifiers]
      public static Net.HttpStatus PROXY_AUTHENTICATION_REQUIRED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EPROXY_AUTHENTICATION_REQUIRED;
      }

      [Modifiers]
      public static Net.HttpStatus REQUEST_TIMEOUT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EREQUEST_TIMEOUT;
      }

      [Modifiers]
      public static Net.HttpStatus CONFLICT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ECONFLICT;
      }

      [Modifiers]
      public static Net.HttpStatus GONE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EGONE;
      }

      [Modifiers]
      public static Net.HttpStatus LENGTH_REQUIRED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ELENGTH_REQUIRED;
      }

      [Modifiers]
      public static Net.HttpStatus PRECONDITION_FAILED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EPRECONDITION_FAILED;
      }

      [Modifiers]
      public static Net.HttpStatus REQUEST_TOO_LONG
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EREQUEST_TOO_LONG;
      }

      [Modifiers]
      public static Net.HttpStatus REQUEST_URI_TOO_LONG
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EREQUEST_URI_TOO_LONG;
      }

      [Modifiers]
      public static Net.HttpStatus UNSUPPORTED_MEDIA_TYPE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EUNSUPPORTED_MEDIA_TYPE;
      }

      [Modifiers]
      public static Net.HttpStatus REQUESTED_RANGE_NOT_SATISFIABLE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EREQUESTED_RANGE_NOT_SATISFIABLE;
      }

      [Modifiers]
      public static Net.HttpStatus EXPECTATION_FAILED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EEXPECTATION_FAILED;
      }

      [Modifiers]
      public static Net.HttpStatus INSUFFICIENT_SPACE_ON_RESOURCE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EINSUFFICIENT_SPACE_ON_RESOURCE;
      }

      [Modifiers]
      public static Net.HttpStatus METHOD_FAILURE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EMETHOD_FAILURE;
      }

      [Modifiers]
      public static Net.HttpStatus UNPROCESSABLE_ENTITY
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EUNPROCESSABLE_ENTITY;
      }

      [Modifiers]
      public static Net.HttpStatus LOCKED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ELOCKED;
      }

      [Modifiers]
      public static Net.HttpStatus FAILED_DEPENDENCY
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EFAILED_DEPENDENCY;
      }

      [Modifiers]
      public static Net.HttpStatus INTERNAL_SERVER_ERROR
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EINTERNAL_SERVER_ERROR;
      }

      [Modifiers]
      public static Net.HttpStatus NOT_IMPLEMENTED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ENOT_IMPLEMENTED;
      }

      [Modifiers]
      public static Net.HttpStatus BAD_GATEWAY
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EBAD_GATEWAY;
      }

      [Modifiers]
      public static Net.HttpStatus SERVICE_UNAVAILABLE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003ESERVICE_UNAVAILABLE;
      }

      [Modifiers]
      public static Net.HttpStatus GATEWAY_TIMEOUT
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EGATEWAY_TIMEOUT;
      }

      [Modifiers]
      public static Net.HttpStatus HTTP_VERSION_NOT_SUPPORTED
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EHTTP_VERSION_NOT_SUPPORTED;
      }

      [Modifiers]
      public static Net.HttpStatus INSUFFICIENT_STORAGE
      {
        [HideFromJava] get => Net.HttpStatus.__\u003C\u003EINSUFFICIENT_STORAGE;
      }

      [Modifiers]
      public int code
      {
        [HideFromJava] get => this.__\u003C\u003Ecode;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecode = value;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        UNKNOWN_STATUS,
        CONTINUE,
        SWITCHING_PROTOCOLS,
        PROCESSING,
        OK,
        CREATED,
        ACCEPTED,
        NON_AUTHORITATIVE_INFORMATION,
        NO_CONTENT,
        RESET_CONTENT,
        PARTIAL_CONTENT,
        MULTI_STATUS,
        MULTIPLE_CHOICES,
        MOVED_PERMANENTLY,
        MOVED_TEMPORARILY,
        SEE_OTHER,
        NOT_MODIFIED,
        USE_PROXY,
        TEMPORARY_REDIRECT,
        BAD_REQUEST,
        UNAUTHORIZED,
        PAYMENT_REQUIRED,
        FORBIDDEN,
        NOT_FOUND,
        METHOD_NOT_ALLOWED,
        NOT_ACCEPTABLE,
        PROXY_AUTHENTICATION_REQUIRED,
        REQUEST_TIMEOUT,
        CONFLICT,
        GONE,
        LENGTH_REQUIRED,
        PRECONDITION_FAILED,
        REQUEST_TOO_LONG,
        REQUEST_URI_TOO_LONG,
        UNSUPPORTED_MEDIA_TYPE,
        REQUESTED_RANGE_NOT_SATISFIABLE,
        EXPECTATION_FAILED,
        INSUFFICIENT_SPACE_ON_RESOURCE,
        METHOD_FAILURE,
        UNPROCESSABLE_ENTITY,
        LOCKED,
        FAILED_DEPENDENCY,
        INTERNAL_SERVER_ERROR,
        NOT_IMPLEMENTED,
        BAD_GATEWAY,
        SERVICE_UNAVAILABLE,
        GATEWAY_TIMEOUT,
        HTTP_VERSION_NOT_SUPPORTED,
        INSUFFICIENT_STORAGE,
      }
    }
  }
}
