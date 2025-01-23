using MSCLoader;
using UnityEngine;

namespace MSCHubcap
{
    public class Hubcap : Mod
    {
        public override string ID => "MSCHubcap";
        public override string Name => "Custom Hubcap";
        public override string Author => "exyxz";
        public override string Version => "0.1";
        public override string Description => "Replaces stock hubcaps with custom one";
        public override bool UseAssetsFolder => true;

        public override void ModSetup()
        {
            SetupFunction(Setup.OnLoad, Mod_OnLoad);
        }

        private void Mod_OnLoad()
        {
            AssetBundle bundle = LoadAssets.LoadBundle(this, "hubcap.unity3d");
            GameObject mGO = Object.Instantiate(bundle.LoadAsset<GameObject>("Hubcap.prefab"));
            bundle.Unload(false);
            GameObject[] hubcaps = GameObject.FindGameObjectsWithTag("PART");
            foreach (GameObject hubcap in hubcaps)
            {
                if (hubcap.name == "hubcap(Clone)")
                {
                    hubcap.GetComponent<MeshFilter>().mesh = mGO.GetComponent<MeshFilter>().mesh;
                    hubcap.GetComponent<MeshRenderer>().material = mGO.GetComponent<MeshRenderer>().material;
                }
            }
        }
    }
}
