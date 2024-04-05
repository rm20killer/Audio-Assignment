namespace Unity.FPS.Gameplay
{
    public class JetpackPickup : Pickup
    {
        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            var jetpack = byPlayer.GetComponent<Jetpack>();
            if (!jetpack)
                return;

            if (jetpack.TryUnlock())
            {
                AkSoundEngine.PostEvent("Play_Jetpack_Pickup", gameObject);
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }
    }
}