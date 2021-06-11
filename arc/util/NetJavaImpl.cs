// Decompiled with JetBrains decompiler
// Type: arc.util.NetJavaImpl
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util.async;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class NetJavaImpl : Object
  {
    [Modifiers]
    private AsyncExecutor asyncExecutor;
    private bool block;

    [LineNumberTable(new byte[] {159, 164, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NetJavaImpl()
    {
      NetJavaImpl netJavaImpl = this;
      this.asyncExecutor = new AsyncExecutor(6);
    }

    [Signature("(Larc/Net$HttpRequest;Larc/func/Cons<Larc/Net$HttpResponse;>;Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [LineNumberTable(new byte[] {159, 169, 104, 112, 193, 167, 112, 102, 103, 127, 12, 127, 7, 98, 177, 141, 127, 1, 105, 104, 109, 171, 190, 109, 141, 255, 12, 106, 2, 98, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void http(Net.HttpRequest request, Cons success, Cons failure)
    {
      if (request.url == null)
      {
        failure.get((object) new ArcRuntimeException("can't process a HTTP request without URL set"));
      }
      else
      {
        Exception exception1;
        try
        {
          Net.HttpMethod method = request.method;
          URL url;
          if (object.ReferenceEquals((object) method, (object) Net.HttpMethod.__\u003C\u003EGET))
          {
            string str = "";
            string content = request.content;
            if (content != null && !String.instancehelper_equals("", (object) content))
              str = new StringBuilder().append("?").append(content).toString();
            URL.__\u003Cclinit\u003E();
            url = new URL(new StringBuilder().append(request.url).append(str).toString());
          }
          else
          {
            URL.__\u003Cclinit\u003E();
            url = new URL(request.url);
          }
          HttpURLConnection httpUrlConnection1 = (HttpURLConnection) url.openConnection();
          int num = object.ReferenceEquals((object) method, (object) Net.HttpMethod.__\u003C\u003EPOST) || object.ReferenceEquals((object) method, (object) Net.HttpMethod.__\u003C\u003EPUT) ? 1 : 0;
          ((URLConnection) httpUrlConnection1).setDoOutput(num != 0);
          ((URLConnection) httpUrlConnection1).setDoInput(true);
          httpUrlConnection1.setRequestMethod(method.toString());
          HttpURLConnection.setFollowRedirects(request.followRedirects);
          ObjectMap headers = request.headers;
          HttpURLConnection httpUrlConnection2 = httpUrlConnection1;
          Objects.requireNonNull((object) httpUrlConnection2);
          Cons2 cons = (Cons2) new NetJavaImpl.__\u003C\u003EAnon0(httpUrlConnection2);
          headers.each(cons);
          ((URLConnection) httpUrlConnection1).setConnectTimeout(request.timeout);
          ((URLConnection) httpUrlConnection1).setReadTimeout(request.timeout);
          this.run((Runnable) new NetJavaImpl.__\u003C\u003EAnon1(num != 0, request, httpUrlConnection1, success, failure));
          return;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception2 = exception1;
        failure.get((object) exception2);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlock(bool block) => this.block = block;

    [LineNumberTable(new byte[] {60, 104, 136, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void run([In] Runnable obj0)
    {
      if (this.block)
        obj0.run();
      else
        this.asyncExecutor.submit(obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 127, 162, 131, 103, 99, 140, 150, 102, 63, 10, 104, 121, 101, 104, 100, 136, 153, 103, 63, 0, 105, 249, 69, 134, 136, 152, 102, 60, 104, 246, 69, 226, 61, 98, 102, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024http\u00240(
      [In] bool obj0,
      [In] Net.HttpRequest obj1,
      [In] HttpURLConnection obj2,
      [In] Cons obj3,
      [In] Cons obj4)
    {
      int num = obj0 ? 1 : 0;
      OutputStreamWriter outputStreamWriter;
      Exception exception1;
      Exception exception2;
      try
      {
        if (num != 0)
        {
          string content = obj1.content;
          if (content != null)
          {
            outputStreamWriter = new OutputStreamWriter(((URLConnection) obj2).getOutputStream());
            try
            {
              ((Writer) outputStreamWriter).write(content);
            }
            catch (Exception ex)
            {
              exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              goto label_8;
            }
            Streams.close((Closeable) outputStreamWriter);
            goto label_24;
          }
          else
            goto label_13;
        }
        else
          goto label_24;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_9;
      }
label_8:
      Exception exception3 = exception1;
      Exception exception4;
      try
      {
        Exception exception5 = exception3;
        Streams.close((Closeable) outputStreamWriter);
        throw Throwable.__\u003Cunmap\u003E(exception5);
      }
      catch (Exception ex)
      {
        exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception6 = exception4;
      goto label_34;
label_9:
      exception6 = exception2;
      goto label_34;
label_13:
      OutputStream outputStream;
      Exception exception7;
      Exception exception8;
      try
      {
        InputStream contentStream = obj1.contentStream;
        if (contentStream != null)
        {
          outputStream = ((URLConnection) obj2).getOutputStream();
          try
          {
            Streams.copy(contentStream, outputStream);
          }
          catch (Exception ex)
          {
            exception7 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_19;
          }
          Streams.close((Closeable) outputStream);
          goto label_24;
        }
        else
          goto label_24;
      }
      catch (Exception ex)
      {
        exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_20;
      }
label_19:
      Exception exception9 = exception7;
      Exception exception10;
      try
      {
        Exception exception5 = exception9;
        Streams.close((Closeable) outputStream);
        throw Throwable.__\u003Cunmap\u003E(exception5);
      }
      catch (Exception ex)
      {
        exception10 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception6 = exception10;
      goto label_34;
label_20:
      exception6 = exception8;
      goto label_34;
label_24:
      Exception exception11;
      Exception exception12;
      try
      {
        ((URLConnection) obj2).connect();
        NetJavaImpl.HttpClientResponse httpClientResponse = new NetJavaImpl.HttpClientResponse(obj2);
        try
        {
          obj3.get((object) httpClientResponse);
        }
        catch (Exception ex)
        {
          exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_29;
        }
        obj2.disconnect();
        return;
      }
      catch (Exception ex)
      {
        exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_30;
      }
label_29:
      Exception exception13 = exception11;
      Exception exception14;
      try
      {
        Exception exception5 = exception13;
        obj2.disconnect();
        throw Throwable.__\u003Cunmap\u003E(exception5);
      }
      catch (Exception ex)
      {
        exception14 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception6 = exception14;
      goto label_34;
label_30:
      exception6 = exception12;
label_34:
      Exception exception15 = exception6;
      obj2.disconnect();
      obj4.get((object) exception15);
    }

    internal class HttpClientResponse : Object, Net.HttpResponse
    {
      [Modifiers]
      private HttpURLConnection connection;
      private Net.HttpStatus status;

      [LineNumberTable(new byte[] {160, 78, 122, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private InputStream getInputStream()
      {
        InputStream inputStream;
        try
        {
          inputStream = ((URLConnection) this.connection).getInputStream();
        }
        catch (IOException ex)
        {
          goto label_3;
        }
        return inputStream;
label_3:
        return this.connection.getErrorStream();
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {71, 104, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public HttpClientResponse([In] HttpURLConnection obj0)
      {
        NetJavaImpl.HttpClientResponse httpClientResponse = this;
        this.connection = obj0;
        this.status = Net.HttpStatus.byCode(obj0.getResponseCode());
      }

      [LineNumberTable(new byte[] {78, 167, 99, 198, 216, 102, 38, 230, 60, 100, 97, 138, 102, 35, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual byte[] getResult()
      {
        InputStream inputStream = this.getInputStream();
        if (inputStream == null)
          return Streams.__\u003C\u003EEMPTY_BYTES;
        byte[] numArray;
        // ISSUE: fault handler
        try
        {
          numArray = Streams.copyBytes(inputStream, ((URLConnection) this.connection).getContentLength());
          goto label_6;
        }
        catch (IOException ex)
        {
        }
        __fault
        {
          Streams.close((Closeable) inputStream);
        }
        try
        {
          return Streams.__\u003C\u003EEMPTY_BYTES;
        }
        finally
        {
          Streams.close((Closeable) inputStream);
        }
label_6:
        Streams.close((Closeable) inputStream);
        return numArray;
      }

      [LineNumberTable(new byte[] {96, 167, 99, 198, 216, 102, 38, 230, 60, 100, 97, 138, 102, 35, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getResultAsString()
      {
        InputStream inputStream = this.getInputStream();
        if (inputStream == null)
          return "";
        string str;
        // ISSUE: fault handler
        try
        {
          str = Streams.copyString(inputStream, ((URLConnection) this.connection).getContentLength());
          goto label_6;
        }
        catch (IOException ex)
        {
        }
        __fault
        {
          Streams.close((Closeable) inputStream);
        }
        try
        {
          return "";
        }
        finally
        {
          Streams.close((Closeable) inputStream);
        }
label_6:
        Streams.close((Closeable) inputStream);
        return str;
      }

      [LineNumberTable(164)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual InputStream getResultAsStream() => this.getInputStream();

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Net.HttpStatus getStatus() => this.status;

      [LineNumberTable(174)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getHeader([In] string obj0) => ((URLConnection) this.connection).getHeaderField(obj0);

      [Signature("()Larc/struct/ObjectMap<Ljava/lang/String;Larc/struct/Seq<Ljava/lang/String;>;>;")]
      [LineNumberTable(new byte[] {160, 66, 102, 108, 127, 1, 99, 159, 10, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectMap getHeaders()
      {
        ObjectMap objectMap = new ObjectMap();
        Map headerFields = ((URLConnection) this.connection).getHeaderFields();
        Iterator iterator = headerFields.keySet().iterator();
        while (iterator.hasNext())
        {
          string str = (string) iterator.next();
          if (str != null)
            objectMap.put((object) str, (object) Seq.with(((List) headerFields.get((object) str)).toArray((object[]) new string[0])));
        }
        return objectMap;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly HttpURLConnection arg\u00241;

      internal __\u003C\u003EAnon0([In] HttpURLConnection obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => ((URLConnection) this.arg\u00241).addRequestProperty((string) obj0, (string) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly bool arg\u00241;
      private readonly Net.HttpRequest arg\u00242;
      private readonly HttpURLConnection arg\u00243;
      private readonly Cons arg\u00244;
      private readonly Cons arg\u00245;

      internal __\u003C\u003EAnon1(
        [In] bool obj0,
        [In] Net.HttpRequest obj1,
        [In] HttpURLConnection obj2,
        [In] Cons obj3,
        [In] Cons obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => NetJavaImpl.lambda\u0024http\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }
  }
}
