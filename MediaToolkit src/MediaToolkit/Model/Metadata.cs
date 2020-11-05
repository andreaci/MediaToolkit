using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaToolkit.Model
{
    public class StreamMetadata {

        //public string Title { get; internal set; }
        public string StreamId { get; internal set; }
        public string Language { get; internal set; }
        //public TimeSpan Duration { get; internal set; }
        public string Format { get; internal set; }
        public int? BitRateKbs { get; internal set; }
    }
    public class VideoStreamMetadata : StreamMetadata
    {
            internal VideoStreamMetadata() { }
            public string ColorModel { get; internal set; }
            public string FrameSize { get; internal set; }
            public double Fps { get; internal set; }
    }
    public class AudioStreamMetadata : StreamMetadata
    {
        internal AudioStreamMetadata() { }

        public string SampleRate { get; internal set; }
        public string ChannelOutput { get; internal set; }
    }
    public class SubtitleStreamMetadata : StreamMetadata
    {
        internal SubtitleStreamMetadata() { }
    }

    public class Metadata
    {
        internal Metadata() { }
        public TimeSpan Duration { get; internal set; }
        public VideoStreamMetadata VideoData { get { return (VideoStreamMetadata)Streams.FirstOrDefault(x => x is VideoStreamMetadata); } }
        public AudioStreamMetadata AudioData { get { return (AudioStreamMetadata)Streams.FirstOrDefault(x => x is AudioStreamMetadata); } }

        public List<StreamMetadata> AudioStreams => Streams.Where(x => x is AudioStreamMetadata).ToList();

        public List<StreamMetadata> Streams = new List<StreamMetadata>(10);

    }
}
