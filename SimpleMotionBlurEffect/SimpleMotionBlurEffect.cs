using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace SimpleMotionBlurEffect
{
    [VideoEffect("간단한 모션 블러", ["가공"], ["motion blur"], IsAviUtlSupported = false)]
    internal class SimpleMotionBlurEffect : VideoEffectBase
    {
        public override string Label => "간단한 모션 블러";

        [Display(GroupName = "간단한 모션 블러", Name = "회전 블러", Description = "회전 블러 효과의 강도")]
        [AnimationSlider("F1", "%", 0, 100)]
        public Animation CircularBlurRate { get; set; } = new Animation(0, 0, 1000);

        [Display(GroupName = "간단한 모션 블러", Name = "방향 블러", Description = "방향 블러 효과의 강도")]
        [AnimationSlider("F1", "%", 0, 100)]
        public Animation DirectionalBlurRate { get; set; } = new Animation(0, 0, 1000);

        [Display(GroupName = "간단한 모션 블러", Name = "방사형 블러", Description = "방사형 블러 효과의 강도")]
        [AnimationSlider("F1", "%", 0, 100)]
        public Animation RadialBlurRate { get; set; } = new Animation(0, 0, 1000);

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SimpleMotionBlurEffectProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => [CircularBlurRate, DirectionalBlurRate, RadialBlurRate];
    }
}