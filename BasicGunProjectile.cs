using System;
using System.Collections;
using UnityEngine;

namespace BasicGun
{
	// Token: 0x0200000C RID: 12
	internal class BasicGunProjectile : MonoBehaviour
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00003E98 File Offset: 0x00002098
		public void Start()
		{
			this.projectile = base.GetComponent<Projectile>();
			this.player = (this.projectile.Owner as PlayerController);
			GameActor owner = this.projectile.Owner;
			Projectile component = base.gameObject.GetComponent<Projectile>();
			if (component != null)
			{
				if (this.goop == null)
				{
					GoopDefinition goopDef = ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<GoopDefinition>("assets/data/goops/water goop.asset");
					this.goop = DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDef);
				}
				if (this.radius == 0f)
				{
					this.radius = 0.75f;
				}
				GameManager.Instance.StartCoroutine(this.GoopTrail(component, this.goop));
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002180 File Offset: 0x00000380
		private IEnumerator GoopTrail(Projectile component, DeadlyDeadlyGoopManager goopManager)
		{
			while (component != null)
			{
				goopManager.TimedAddGoopCircle(component.specRigidbody.UnitCenter, this.radius, 0.5f, false);
				yield return new WaitForSeconds(0.01f);
			}
			yield break;
		}

		// Token: 0x04000017 RID: 23
		private Projectile projectile;

		// Token: 0x04000018 RID: 24
		private PlayerController player;

		// Token: 0x04000019 RID: 25
		public float radius;

		// Token: 0x0400001A RID: 26
		public DeadlyDeadlyGoopManager goop;
	}
}
