using System;
using ItemAPI;

namespace BasicGun
{
	// Token: 0x0200000F RID: 15
	public class ModTest : ETGModule
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00002103 File Offset: 0x00000303
		public override void Init()
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000021CB File Offset: 0x000003CB
		public override void Start()
		{
			FakePrefabHooks.Init();
			ItemBuilder.Init();
			BasicGun.Add();
			ETGModConsole.Log("Sail Ready", true);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002103 File Offset: 0x00000303
		public override void Exit()
		{
		}

		// Token: 0x04000025 RID: 37
		public static readonly string MOD_NAME = "SailCloth";

		// Token: 0x04000026 RID: 38
		public static readonly string VERSION = "0.0.0.";

		// Token: 0x04000027 RID: 39
		public static readonly string TEXT_COLOR = "#40E1A9";
	}
}
