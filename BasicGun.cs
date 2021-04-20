using System;
using Gungeon;
using ItemAPI;
using UnityEngine;

namespace BasicGun
{
	// Token: 0x0200000B RID: 11
	public class BasicGun : GunBehaviour
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00003C64 File Offset: 0x00001E64
		public static void Add()
		{
			Gun gun = ETGMod.Databases.Items.NewGun("Sail Cloth", "sail");
			Game.Items.Rename("outdated_gun_mods:sail_cloth", "jn:sail_cloth");
			gun.gameObject.AddComponent<BasicGun>();
			gun.SetShortDescription("Weeeeeeeee");
			gun.SetLongDescription("A piece of cloth that was left behind by a peculiar sailor. The magic of the gungeon has given it a new course.");
			gun.SetupSprite(null, "sail_idle_001", 8);
			gun.SetAnimationFPS(gun.shootAnimation, 24);
			gun.AddProjectileModuleFrom(PickupObjectDatabase.GetById(520) as Gun, true, false);
			gun.DefaultModule.ammoCost = 1;
			gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
			gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			gun.reloadTime = 1f;
			gun.DefaultModule.cooldownTime = 0.01f;
			gun.DefaultModule.numberOfShotsInClip = 1000;
			gun.SetBaseMaxAmmo(1000);
			gun.quality = PickupObject.ItemQuality.B;
			gun.muzzleFlashEffects = null;
			gun.encounterTrackable.EncounterGuid = "SailCloth";
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			gun.DefaultModule.projectiles[0] = projectile;
			projectile.AdditionalScaleMultiplier = 0.75f;
			projectile.pierceMinorBreakables = true;
			projectile.AppliesStun = true;
			projectile.collidesWithProjectiles = true;
			projectile.baseData.damage = 12f;
			projectile.baseData.force = 160f;
			projectile.baseData.speed = 17.5f;
			projectile.baseData.range = 15f;
			projectile.AppliesKnockbackToPlayer = true;
			projectile.PlayerKnockbackForce = -65f;
			projectile.transform.parent = gun.barrelOffset;
			ETGMod.Databases.Items.Add(gun, null, "ANY");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002141 File Offset: 0x00000341
		public override void OnPostFired(PlayerController player, Gun gun)
		{
			gun.PreventNormalFireAudio = true;
			AkSoundEngine.PostEvent("none", base.gameObject);
			player.ReceivesTouchDamage = false;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002103 File Offset: 0x00000303
		public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003E44 File Offset: 0x00002044
		protected void Update(PlayerController player, Gun gun)
		{
			if (this.gun.CurrentOwner)
			{
				if (!this.gun.PreventNormalFireAudio)
				{
					this.gun.PreventNormalFireAudio = true;
				}
				if (!this.gun.IsReloading && !this.HasReloaded)
				{
					this.HasReloaded = true;
				}
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000216A File Offset: 0x0000036A
		public override void PostProcessProjectile(Projectile projectile)
		{
			projectile.gameObject.AddComponent<BasicGunProjectile>();
		}

		// Token: 0x04000016 RID: 22
		private bool HasReloaded;
	}
}
