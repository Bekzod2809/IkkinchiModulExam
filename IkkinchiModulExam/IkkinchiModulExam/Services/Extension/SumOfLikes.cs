using IkkinchiModulExam.Dtos;

namespace IkkinchiModulExam.Services.Extension;

static public class SumOfLikes
{
    static int SumOfLike(this MusicGetDto music)
    {
        int sum = 0;
        for (int i = 0; i < music.QuentityLikes; i++)
        {
            sum = sum + music.QuentityLikes;
        }
        return sum;
    }
}
