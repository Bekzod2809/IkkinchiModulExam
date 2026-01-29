using IkkinchiModulExam.Dtos;

namespace IkkinchiModulExam.Services.Extension;

static public class MBtoKB
{
    static double MBtoKB(this MusicGetDto music)
    {
        double sum = music.MB * 8.0;
        return sum;
    }
}
