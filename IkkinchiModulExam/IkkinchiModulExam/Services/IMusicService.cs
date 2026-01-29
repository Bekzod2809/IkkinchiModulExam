using IkkinchiModulExam.Dtos;

namespace IkkinchiModulExam.Services;

public interface IMusicService
{
    public Guid AddMusic(MusicCreateDto musicCreateDto);
    public List<MusicGetDto> GetAllMusics();
    public MusicGetDto? GetMusicById(Guid musicId);
    public bool DeleteMusic(Guid musicId);
    public bool UpdateMusic(Guid musicId, MusicUpdateDto musicUpdateDto);
    public List<MusicGetDto> GetAllMusicByAuthorName(string authorName);
    public MusicGetDto GetMostLikedMusic();
    public MusicGetDto? GetMusicByName(string name);
    public List<MusicGetDto> GetAllMusicAboveSize(double minSize);
    public List<MusicGetDto> GetAllMusicAboveSize1(double maxSize);

    public List<MusicGetDto> GetTopMostLikedMUsic(int count);
    public List<MusicGetDto> GetMusicWithLikesInRange(int minLIkes, int maxLIkes);
    public double GetTotalMusicSizeByAuthorName(string authorName);
}