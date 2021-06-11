// Decompiled with JetBrains decompiler
// Type: arc.assets.AssetLoadingTask
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.assets.loaders;
using arc.files;
using arc.util;
using arc.util.async;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace arc.assets
{
  [Signature("Ljava/lang/Object;Larc/util/async/AsyncTask<Ljava/lang/Void;>;")]
  internal class AssetLoadingTask : Object, AsyncTask
  {
    [Modifiers]
    internal AssetDescriptor assetDesc;
    [Modifiers]
    internal AssetLoader loader;
    [Modifiers]
    internal AsyncExecutor executor;
    [Modifiers]
    internal long startTime;
    internal AssetManager manager;
    internal volatile bool asyncDone;
    internal volatile bool dependenciesLoaded;
    [Signature("Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    internal volatile Seq dependencies;
    [Signature("Larc/util/async/AsyncResult<Ljava/lang/Void;>;")]
    internal volatile AsyncResult depsFuture;
    [Signature("Larc/util/async/AsyncResult<Ljava/lang/Void;>;")]
    internal volatile AsyncResult loadFuture;
    internal volatile object asset;
    internal int ticks;
    internal volatile bool cancel;

    [LineNumberTable(new byte[] {82, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Fi resolve([In] AssetLoader obj0, [In] AssetDescriptor obj1)
    {
      if (obj1.file == null)
        obj1.file = obj0.resolve(obj1.__\u003C\u003EfileName);
      return obj1.file;
    }

    [Signature("(Larc/struct/Seq<Larc/assets/AssetDescriptor;>;)V")]
    [LineNumberTable(new byte[] {91, 103, 103, 110, 114, 114, 111, 127, 21, 9, 232, 61, 233, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void removeDuplicates([In] Seq obj0)
    {
      int num = obj0.ordered ? 1 : 0;
      obj0.ordered = true;
      for (int index1 = 0; index1 < obj0.size; ++index1)
      {
        string fileName = ((AssetDescriptor) obj0.get(index1)).__\u003C\u003EfileName;
        Class type = ((AssetDescriptor) obj0.get(index1)).__\u003C\u003Etype;
        for (int index2 = obj0.size - 1; index2 > index1; index2 += -1)
        {
          if (object.ReferenceEquals((object) type, (object) ((AssetDescriptor) obj0.get(index2)).__\u003C\u003Etype) && String.instancehelper_equals(fileName, (object) ((AssetDescriptor) obj0.get(index2)).__\u003C\u003EfileName))
            obj0.remove(index2);
        }
      }
      obj0.ordered = num != 0;
    }

    [LineNumberTable(new byte[] {30, 108, 109, 110, 127, 28, 106, 127, 34, 129, 110, 159, 1, 159, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void handleSyncLoader()
    {
      SynchronousAssetLoader loader = (SynchronousAssetLoader) this.loader;
      if (!this.dependenciesLoaded)
      {
        this.dependenciesLoaded = true;
        Thread.MemoryBarrier();
        this.dependencies = loader.getDependencies(this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
        Thread.MemoryBarrier();
        if (this.dependencies == null)
        {
          this.asset = loader.load(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
          Thread.MemoryBarrier();
        }
        else
        {
          this.removeDuplicates(this.dependencies);
          this.manager.injectDependencies(this.assetDesc.__\u003C\u003EfileName, this.dependencies);
        }
      }
      else
      {
        this.asset = loader.load(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
        Thread.MemoryBarrier();
      }
    }

    [LineNumberTable(new byte[] {46, 108, 109, 106, 158, 146, 191, 6, 2, 97, 159, 17, 110, 109, 255, 39, 69, 116, 158, 106, 127, 39, 146, 191, 6, 2, 97, 159, 17, 223, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void handleAsyncLoader()
    {
      AsynchronousAssetLoader loader = (AsynchronousAssetLoader) this.loader;
      if (!this.dependenciesLoaded)
      {
        if (this.depsFuture == null)
        {
          this.depsFuture = this.executor.submit((AsyncTask) this);
          Thread.MemoryBarrier();
        }
        else
        {
          if (!this.depsFuture.isDone())
            return;
          Exception exception1;
          try
          {
            this.depsFuture.get();
            goto label_9;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception1 = (Exception) m0;
          }
          Exception exception2 = exception1;
          string message = new StringBuilder().append("Couldn't load dependencies of asset: ").append(this.assetDesc.__\u003C\u003EfileName).toString();
          Exception exception3 = exception2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message, (Exception) exception3);
label_9:
          this.dependenciesLoaded = true;
          Thread.MemoryBarrier();
          if (!this.asyncDone)
            return;
          this.asset = loader.loadSync(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
          Thread.MemoryBarrier();
        }
      }
      else if (this.loadFuture == null && !this.asyncDone)
      {
        this.loadFuture = this.executor.submit((AsyncTask) this);
        Thread.MemoryBarrier();
      }
      else if (this.asyncDone)
      {
        this.asset = loader.loadSync(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
        Thread.MemoryBarrier();
      }
      else
      {
        if (!this.loadFuture.isDone())
          return;
        Exception exception1;
        try
        {
          this.loadFuture.get();
          goto label_23;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        string message = new StringBuilder().append("Couldn't load asset: ").append(this.assetDesc.__\u003C\u003EfileName).toString();
        Exception exception3 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) exception3);
label_23:
        this.asset = loader.loadSync(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
        Thread.MemoryBarrier();
      }
    }

    [LineNumberTable(new byte[] {159, 187, 108, 109, 127, 28, 106, 110, 191, 4, 127, 21, 176, 159, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Void call()
    {
      AsynchronousAssetLoader loader = (AsynchronousAssetLoader) this.loader;
      if (!this.dependenciesLoaded)
      {
        this.dependencies = loader.getDependencies(this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
        Thread.MemoryBarrier();
        if (this.dependencies != null)
        {
          this.removeDuplicates(this.dependencies);
          this.manager.injectDependencies(this.assetDesc.__\u003C\u003EfileName, this.dependencies);
        }
        else
        {
          loader.loadAsync(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
          this.asyncDone = true;
          Thread.MemoryBarrier();
        }
      }
      else
        loader.loadAsync(this.manager, this.assetDesc.__\u003C\u003EfileName, this.resolve(this.loader, this.assetDesc), this.assetDesc.__\u003C\u003Eparams);
      return (Void) null;
    }

    [LineNumberTable(new byte[] {159, 176, 232, 54, 105, 137, 105, 105, 137, 103, 174, 103, 103, 103, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetLoadingTask(
      [In] AssetManager obj0,
      [In] AssetDescriptor obj1,
      [In] AssetLoader obj2,
      [In] AsyncExecutor obj3)
    {
      AssetLoadingTask assetLoadingTask = this;
      this.asyncDone = false;
      this.dependenciesLoaded = false;
      this.depsFuture = (AsyncResult) null;
      this.loadFuture = (AsyncResult) null;
      this.asset = (object) null;
      this.ticks = 0;
      this.cancel = false;
      Thread.MemoryBarrier();
      this.manager = obj0;
      this.assetDesc = obj1;
      this.loader = obj2;
      this.executor = obj3;
      this.startTime = Time.nanos();
    }

    [LineNumberTable(new byte[] {20, 110, 109, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool update()
    {
      ++this.ticks;
      if (this.loader is SynchronousAssetLoader)
        this.handleSyncLoader();
      else
        this.handleAsyncLoader();
      return this.asset != null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getAsset() => this.asset;

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call() => (object) this.call();
  }
}
