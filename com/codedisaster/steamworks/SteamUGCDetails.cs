// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUGCDetails
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamUGCDetails : Object
  {
    internal long publishedFileID;
    internal int result;
    internal int fileType;
    internal string title;
    internal string description;
    internal long ownerID;
    internal int timeCreated;
    internal int timeUpdated;
    internal bool tagsTruncated;
    internal string tags;
    internal long fileHandle;
    internal long previewFileHandle;
    internal string fileName;
    internal int fileSize;
    internal int previewFileSize;
    internal string url;
    internal int votesUp;
    internal int votesDown;

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamUGCDetails()
    {
    }

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamResult getResult() => SteamResult.byValue(this.result);

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getOwnerID()
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(this.ownerID);
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamPublishedFileID getPublishedFileID() => new SteamPublishedFileID(this.publishedFileID);

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamRemoteStorage.WorkshopFileType getFileType() => SteamRemoteStorage.WorkshopFileType.byOrdinal(this.fileType);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getTitle() => this.title;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getDescription() => this.description;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTimeCreated() => this.timeCreated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTimeUpdated() => this.timeUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool areTagsTruncated() => this.tagsTruncated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getTags() => this.tags;

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCHandle getFileHandle() => new SteamUGCHandle(this.fileHandle);

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCHandle getPreviewFileHandle() => new SteamUGCHandle(this.previewFileHandle);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFileName() => this.fileName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFileSize() => this.fileSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPreviewFileSize() => this.previewFileSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getURL() => this.url;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVotesUp() => this.votesUp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVotesDown() => this.votesDown;
  }
}
