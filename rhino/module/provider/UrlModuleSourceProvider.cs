// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.UrlModuleSourceProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.module.provider
{
  public class UrlModuleSourceProvider : ModuleSourceProviderBase
  {
    [Modifiers]
    [Signature("Ljava/lang/Iterable<Ljava/net/URI;>;")]
    private Iterable privilegedUris;
    [Modifiers]
    [Signature("Ljava/lang/Iterable<Ljava/net/URI;>;")]
    private Iterable fallbackUris;
    [Modifiers]
    private UrlConnectionSecurityDomainProvider urlConnectionSecurityDomainProvider;
    [Modifiers]
    private UrlConnectionExpiryCalculator urlConnectionExpiryCalculator;

    [Signature("(Ljava/lang/Iterable<Ljava/net/URI;>;Ljava/lang/Iterable<Ljava/net/URI;>;Lrhino/module/provider/UrlConnectionExpiryCalculator;Lrhino/module/provider/UrlConnectionSecurityDomainProvider;)V")]
    [LineNumberTable(new byte[] {11, 104, 103, 103, 103, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UrlModuleSourceProvider(
      Iterable privilegedUris,
      Iterable fallbackUris,
      UrlConnectionExpiryCalculator urlConnectionExpiryCalculator,
      UrlConnectionSecurityDomainProvider urlConnectionSecurityDomainProvider)
    {
      UrlModuleSourceProvider moduleSourceProvider = this;
      this.privilegedUris = privilegedUris;
      this.fallbackUris = fallbackUris;
      this.urlConnectionExpiryCalculator = urlConnectionExpiryCalculator;
      this.urlConnectionSecurityDomainProvider = urlConnectionSecurityDomainProvider;
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [Signature("(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Iterable<Ljava/net/URI;>;)Lrhino/module/provider/ModuleSource;")]
    [LineNumberTable(new byte[] {36, 99, 130, 123, 99, 39, 134, 99, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ModuleSource loadFromPathList([In] string obj0, [In] object obj1, [In] Iterable obj2)
    {
      if (obj2 == null)
        return (ModuleSource) null;
      Iterator iterator = obj2.iterator();
      while (iterator.hasNext())
      {
        URI @base = (URI) iterator.next();
        ModuleSource moduleSource = this.loadFromUri(@base.resolve(obj0), @base, obj1);
        if (moduleSource != null)
          return moduleSource;
      }
      return (ModuleSource) null;
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [LineNumberTable(new byte[] {53, 127, 6, 170, 106, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ModuleSource loadFromUri(
      URI uri,
      URI @base,
      object validator)
    {
      URI.__\u003Cclinit\u003E();
      return this.loadFromActualUri(new URI(new StringBuilder().append((object) uri).append(".js").toString()), @base, validator) ?? this.loadFromActualUri(uri, @base, validator);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {63, 125, 102, 136, 104, 103, 143, 98, 131, 100, 168, 102, 110, 135, 103, 191, 38, 104, 63, 45, 193, 97, 98, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual ModuleSource loadFromActualUri(
      URI uri,
      URI @base,
      object validator)
    {
      URL.__\u003Cclinit\u003E();
      URL url = new URL(@base?.toURL(), uri.toString());
      long num = java.lang.System.currentTimeMillis();
      URLConnection urlConnection = this.openUrlConnection(url);
      UrlModuleSourceProvider.URLValidator urlValidator1;
      if (validator is UrlModuleSourceProvider.URLValidator)
      {
        UrlModuleSourceProvider.URLValidator urlValidator2 = (UrlModuleSourceProvider.URLValidator) validator;
        urlValidator1 = !urlValidator2.appliesTo(uri) ? (UrlModuleSourceProvider.URLValidator) null : urlValidator2;
      }
      else
        urlValidator1 = (UrlModuleSourceProvider.URLValidator) null;
      urlValidator1?.applyConditionals(urlConnection);
      ModuleSource notModified;
      RuntimeException runtimeException1;
      IOException ioException1;
      try
      {
        try
        {
          try
          {
            urlConnection.connect();
            if (urlValidator1 != null)
            {
              if (!urlValidator1.updateValidator(urlConnection, num, this.urlConnectionExpiryCalculator))
              {
                this.close(urlConnection);
                notModified = ModuleSourceProvider.NOT_MODIFIED;
              }
              else
                goto label_17;
            }
            else
              goto label_17;
          }
          catch (FileNotFoundException ex)
          {
            goto label_14;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException1 = (RuntimeException) m0;
            goto label_15;
          }
        }
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_16;
      }
      return notModified;
label_14:
      goto label_27;
label_15:
      RuntimeException runtimeException2 = runtimeException1;
      goto label_28;
label_16:
      runtimeException2 = (RuntimeException) ioException1;
      goto label_28;
label_17:
      ModuleSource moduleSource;
      RuntimeException runtimeException3;
      IOException ioException2;
      try
      {
        try
        {
          try
          {
            moduleSource = new ModuleSource(UrlModuleSourceProvider.getReader(urlConnection), this.getSecurityDomain(urlConnection), uri, @base, (object) new UrlModuleSourceProvider.URLValidator(uri, urlConnection, num, this.urlConnectionExpiryCalculator));
          }
          catch (FileNotFoundException ex)
          {
            goto label_24;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException3 = (RuntimeException) m0;
            goto label_25;
          }
        }
      }
      catch (IOException ex)
      {
        ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_26;
      }
      return moduleSource;
label_24:
      null = null;
      goto label_27;
label_25:
      runtimeException2 = runtimeException3;
      goto label_28;
label_26:
      runtimeException2 = (RuntimeException) ioException2;
      goto label_28;
label_27:
      return (ModuleSource) null;
label_28:
      Exception exception = (Exception) runtimeException2;
      this.close(urlConnection);
      throw Throwable.__\u003Cunmap\u003E((Exception) exception);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(200)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual URLConnection openUrlConnection(URL url) => url.openConnection();

    [LineNumberTable(new byte[] {126, 189, 2, 97, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void close([In] URLConnection obj0)
    {
      IOException ioException;
      try
      {
        obj0.getInputStream().close();
        return;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException cause = ioException;
      this.onFailedClosingUrlConnection(obj0, cause);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {100, 103, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Reader getReader([In] URLConnection obj0) => (Reader) new InputStreamReader(obj0.getInputStream(), UrlModuleSourceProvider.getCharacterEncoding(obj0));

    [LineNumberTable(new byte[] {119, 114, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getSecurityDomain([In] URLConnection obj0) => this.urlConnectionSecurityDomainProvider == null ? (object) null : this.urlConnectionSecurityDomainProvider.getSecurityDomain(obj0);

    [LineNumberTable(new byte[] {105, 97, 107, 103, 99, 130, 103, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getCharacterEncoding([In] URLConnection obj0)
    {
      ParsedContentType parsedContentType = new ParsedContentType(obj0.getContentType());
      string encoding = parsedContentType.getEncoding();
      if (encoding != null)
        return encoding;
      string contentType = parsedContentType.getContentType();
      return contentType != null && String.instancehelper_startsWith(contentType, "text/") ? "8859_1" : "utf-8";
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void onFailedClosingUrlConnection(
      URLConnection urlConnection,
      IOException cause)
    {
    }

    [Signature("(Ljava/lang/Iterable<Ljava/net/URI;>;Ljava/lang/Iterable<Ljava/net/URI;>;)V")]
    [LineNumberTable(new byte[] {159, 180, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UrlModuleSourceProvider(Iterable privilegedUris, Iterable fallbackUris)
      : this(privilegedUris, fallbackUris, (UrlConnectionExpiryCalculator) new DefaultUrlConnectionExpiryCalculator(), (UrlConnectionSecurityDomainProvider) null)
    {
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ModuleSource loadFromPrivilegedLocations(
      string moduleId,
      object validator)
    {
      return this.loadFromPathList(moduleId, validator, this.privilegedUris);
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ModuleSource loadFromFallbackLocations(
      string moduleId,
      object validator)
    {
      return this.loadFromPathList(moduleId, validator, this.fallbackUris);
    }

    [LineNumberTable(new byte[] {160, 91, 110, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool entityNeedsRevalidation(object validator) => !(validator is UrlModuleSourceProvider.URLValidator) || ((UrlModuleSourceProvider.URLValidator) validator).entityNeedsRevalidation();

    [InnerClass]
    internal class URLValidator : Object
    {
      [Modifiers]
      private URI uri;
      [Modifiers]
      private long lastModified;
      [Modifiers]
      private string entityTags;
      private long expiry;

      [LineNumberTable(316)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool appliesTo([In] URI obj0) => this.uri.equals((object) obj0);

      [LineNumberTable(new byte[] {160, 206, 106, 140, 118, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void applyConditionals([In] URLConnection obj0)
      {
        if (this.lastModified != 0L)
          obj0.setIfModifiedSince(this.lastModified);
        if (this.entityTags == null || String.instancehelper_length(this.entityTags) <= 0)
          return;
        obj0.addRequestProperty("If-None-Match", this.entityTags);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 111, 104, 99, 175})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool updateValidator(
        [In] URLConnection obj0,
        [In] long obj1,
        [In] UrlConnectionExpiryCalculator obj2)
      {
        int num = this.isResourceChanged(obj0) ? 1 : 0;
        if (num == 0)
          this.expiry = this.calculateExpiry(obj0, obj1, obj2);
        return num != 0;
      }

      [LineNumberTable(new byte[] {160, 101, 104, 103, 108, 109, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public URLValidator(
        [In] URI obj0,
        [In] URLConnection obj1,
        [In] long obj2,
        [In] UrlConnectionExpiryCalculator obj3)
      {
        UrlModuleSourceProvider.URLValidator urlValidator = this;
        this.uri = obj0;
        this.lastModified = obj1.getLastModified();
        this.entityTags = this.getEntityTags(obj1);
        this.expiry = this.calculateExpiry(obj1, obj2, obj3);
      }

      [LineNumberTable(329)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool entityNeedsRevalidation() => java.lang.System.currentTimeMillis() > this.expiry;

      [LineNumberTable(new byte[] {160, 188, 118, 107, 130, 102, 103, 114, 104, 158})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string getEntityTags([In] URLConnection obj0)
      {
        List list = (List) obj0.getHeaderFields().get((object) "ETag");
        if (list == null || list.isEmpty())
          return (string) null;
        StringBuilder stringBuilder = new StringBuilder();
        Iterator iterator = list.iterator();
        stringBuilder.append((string) iterator.next());
        while (iterator.hasNext())
          stringBuilder.append(", ").append((string) iterator.next());
        return stringBuilder.toString();
      }

      [LineNumberTable(new byte[] {160, 131, 119, 131, 140, 102, 125, 131, 104, 100, 103, 101, 38, 135, 105, 45, 135, 102, 135, 135, 173, 143, 102, 131, 105, 37})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private long calculateExpiry(
        [In] URLConnection obj0,
        [In] long obj1,
        [In] UrlConnectionExpiryCalculator obj2)
      {
        if (String.instancehelper_equals("no-cache", (object) obj0.getHeaderField("Pragma")))
          return 0;
        string headerField = obj0.getHeaderField("Cache-Control");
        if (headerField != null)
        {
          string str = headerField;
          object obj = (object) "no-cache";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (String.instancehelper_contains(str, charSequence2))
            return 0;
          int maxAge = this.getMaxAge(headerField);
          if (-1 != maxAge)
          {
            long num1 = java.lang.System.currentTimeMillis();
            long num2 = Math.max(Math.max(0L, num1 - obj0.getDate()), (long) obj0.getHeaderFieldInt("Age", 0) * 1000L) + (num1 - obj1);
            long num3 = num1 - num2;
            return (long) maxAge * 1000L + num3;
          }
        }
        long headerFieldDate = obj0.getHeaderFieldDate("Expires", -1L);
        if (headerFieldDate != -1L)
          return headerFieldDate;
        return obj2 == null ? 0L : obj2.calculateExpiry(obj0);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 121, 104, 179})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isResourceChanged([In] URLConnection obj0) => obj0 is HttpURLConnection ? ((HttpURLConnection) obj0).getResponseCode() == 304 : this.lastModified != obj0.getLastModified();

      [LineNumberTable(new byte[] {160, 165, 108, 100, 130, 108, 100, 130, 140, 100, 140, 171, 120, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int getMaxAge([In] string obj0)
      {
        int num1 = String.instancehelper_indexOf(obj0, "max-age");
        if (num1 == -1)
          return -1;
        int num2 = String.instancehelper_indexOf(obj0, 61, num1 + 7);
        if (num2 == -1)
          return -1;
        int num3 = String.instancehelper_indexOf(obj0, 44, num2 + 1);
        string str = num3 != -1 ? String.instancehelper_substring(obj0, num2 + 1, num3) : String.instancehelper_substring(obj0, num2 + 1);
        int num4;
        try
        {
          num4 = Integer.parseInt(str);
        }
        catch (NumberFormatException ex)
        {
          goto label_8;
        }
        return num4;
label_8:
        return -1;
      }
    }
  }
}
