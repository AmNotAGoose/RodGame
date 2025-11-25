using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using osuTK;

namespace RodGame.Game.Gameplay.Models
{
    public class ChartModel
    {
        public string Name;
        public string SongId;
        public string SongName;
        public string AuthorName;

        public List<RodModel> RodModels = new();

        public ChartModel(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);

            var chartDto = JsonConvert.DeserializeObject<ChartDto>(json);

            if (chartDto == null) throw new Exception("Failed to parse chart JSON.");

            Name = chartDto.Name;
            SongId = chartDto.SongId;
            SongName = chartDto.SongName;
            AuthorName = chartDto.AuthorName;

            foreach (var rodDto in chartDto.RodModels)
            {
                var rod = new RodModel
                {
                    Id = rodDto.Id,
                    StartPosition = new Vector2(rodDto.StartPosition[0], rodDto.StartPosition[1]),
                    StartTime = rodDto.StartTime,
                    StartRotationSpeed = rodDto.StartRotationSpeed,
                    Events = rodDto.Events ?? new List<RodEventModel>(),
                    NoteModels = new List<NoteModel>()
                };

                if (rodDto.NoteModels != null)
                {
                    foreach (var noteDto in rodDto.NoteModels)
                    {
                        var note = new NoteModel
                        {
                            Id = noteDto.Id,
                            StartPosition = new Vector2(noteDto.StartPosition[0], noteDto.StartPosition[1]),
                            StartTime = noteDto.StartTime
                        };
                        rod.NoteModels.Add(note);
                    }
                }

                RodModels.Add(rod);
            }
        }

        private class ChartDto
        {
            public string Name;
            public string SongId;
            public string SongName;
            public string AuthorName;
            public List<RodDto> RodModels;
        }

        private class RodDto
        {
            public int Id;
            public float[] StartPosition;
            public double StartTime;
            public float StartRotationSpeed;
            public List<RodEventModel> Events;
            public List<NoteDto> NoteModels;
        }

        private class NoteDto
        {
            public int Id;
            public float[] StartPosition;
            public double StartTime;
        }
    }
}
