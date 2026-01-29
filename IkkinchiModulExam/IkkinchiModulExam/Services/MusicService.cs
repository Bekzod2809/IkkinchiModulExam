using IkkinchiModulExam.Dtos;
using IkkinchiModulExam.Entities;

namespace IkkinchiModulExam.Services;

public class MusicService : IMusicService
{
    private List<Music> Musics;
    public MusicService()
    {
        Musics = new List<Music>();
    }
    public bool DeleteMusic(Guid musicId)
    {
        foreach (var music in Musics)
        {
            if (music.Id == musicId)
            {
                Musics.Remove(music);
                return true;
            }
        }
        return false;
    }

    public List<MusicGetDto> GetAllMusicAboveSize(double minSize)
    {
        List<Music> musics = new List<Music>();
        foreach (var music in Musics)
        {
            if (music.MB < minSize)
            {
                musics.Add(music);
            }
        }
        return ToMusicGetDtos(musics);
    }

    public List<MusicGetDto> GetAllMusicByAuthorName(string authorName)
    {
        List<Music> musics = new List<Music>();
        foreach (var music in Musics)
        {
            if (music.AuthorName == authorName)
            {
                musics.Add(music);
            }
        }
        return ToMusicGetDtos(musics);
    }

    public List<MusicGetDto> GetAllMusics()
    {
        var musicGetDtos = ToMusicGetDtos(Musics);
        return musicGetDtos;
    }

    public MusicGetDto GetMostLikedMusic()
    {
        var musicWithMaxLike = Musics[0];
        foreach (var music in Musics)
        {
            if (musicWithMaxLike.QuentityLikes < music.QuentityLikes)
            {
                musicWithMaxLike = music;
            }
        }

        return ToMusicGetDto(musicWithMaxLike);
    }

    public MusicGetDto? GetMusicByName(string name)
    {
        foreach (var music in Musics)
        {
            if (music.Name == name)
            {
                return ToMusicGetDto(music);
            }
        }
        return null;
    }

    public List<MusicGetDto> GetMusicWithLikesInRange(int minLIkes, int maxLIkes)
    {
        List<Music> musics = new List<Music>();

        foreach (var music in Musics)
        {
            if (music.QuentityLikes < maxLIkes && music.QuentityLikes > minLIkes)
            {
                musics.Add(music);
            }
        }
        return ToMusicGetDtos(musics);
    }

    public List<MusicGetDto> GetTopMostLikedMUsic(int count)
    {
        List<Music> musics = new List<Music>();
        var musicWithMaxLike = Musics[0];
        foreach (var music in Musics)
        {
            if (musicWithMaxLike.QuentityLikes < music.QuentityLikes && music.QuentityLikes > count)
            {
                musicWithMaxLike = music;
                musics.Add(music);
            }
        }
        return ToMusicGetDtos(musics);
    }

    public double GetTotalMusicSizeByAuthorName(string authorName)
    {
        double count = 0;
        foreach (var music in Musics)
        {
            if (music.AuthorName == authorName)
            {
                count = count + music.MB;
            }
        }
        return count;
    }
    public bool UpdateMusic(Guid musicId, MusicUpdateDto musicUpdateDto)
    {
        foreach (var music in Musics)
        {
            if (music.Id == musicId)
            {
                music.Name = musicUpdateDto.Name;
                music.MB = musicUpdateDto.MB;
                music.AuthorName = musicUpdateDto.AuthorName;
                music.Description = musicUpdateDto.Description;
                music.QuentityLikes = musicUpdateDto.QuentityLikes;
                return true;
            }
        }
        return false;
    }
    public Guid AddMusic(MusicCreateDto musicCreateDto)
    {
        var music = new Music()
        {
            Id = Guid.NewGuid(),
            Name = musicCreateDto.Name,
            MB = musicCreateDto.MB,
            AuthorName = musicCreateDto.AuthorName,
            Description = musicCreateDto.Description,
            QuentityLikes = musicCreateDto.QuentityLikes,
        };
        Musics.Add(music);
        return music.Id;
    }
    public MusicGetDto? GetMusicById(Guid musicId)
    {
        foreach (var music in Musics)
        {
            if (music.Id == musicId)
            {
                return ToMusicGetDto(music);
            }
        }
        return null;
    }
    private List<MusicGetDto> ToMusicGetDtos(List<Music> musics)
    {
        var musicGetDtos = new List<MusicGetDto>();
        foreach (var music in musics)
        {
            musicGetDtos.Add(ToMusicGetDto(music));
        }
        return musicGetDtos;
    }
    private MusicGetDto ToMusicGetDto(Music music)
    {
        return new MusicGetDto()
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }

    public List<MusicGetDto> GetAllMusicAboveSize1(double maxSize)
    {
        List<Music> musics = new List<Music>();
        foreach (var music in Musics)
        {
            if (music.MB > maxSize)
            {
                musics.Add(music);
            }
        }
        return ToMusicGetDtos(musics);
    }
}
