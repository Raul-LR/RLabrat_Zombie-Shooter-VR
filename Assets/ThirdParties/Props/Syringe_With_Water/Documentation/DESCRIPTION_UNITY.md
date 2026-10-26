# Package name

Syringe with Water and Protective Cap

# Category

3D/Props/Tools

# Summary

A realistic 10 ml syringe with clear water, a fitted protective cap, clean UVs and a ready-to-use URP prefab.

Characters: 109.

# Description

A realistic, unbranded 10 ml syringe prop with a transparent barrel, black graduations, a white plunger, a rubber piston, a steel needle under a fitted protective cap, clear water and a small trapped air bubble. Designed for hospital, laboratory, survival and inventory scenes in games.

One assembled prefab with nine named parts, eight assigned materials and an Overview scene. Adjust materials or replace the scale texture to fit your scene. The water level and protective cap are supplied in the pictured fixed pose. No gameplay scripts or runtime plugins are needed.

# Technical details

| Field | Value |
|---|---|
| Number of textures | 2 used by the Unity package |
| Texture dimensions | 2048 × 2048 each |
| Polygon count of Syringe with Water | 8,908 explicitly triangulated faces total |
| Minimum polygon count | 8,908 per standalone asset; the product contains one asset |
| Maximum polygon count | 8,908 per standalone asset |
| Number of meshes/prefabs | 9 component meshes / 1 complete prefab |
| Rigging: Yes/No | No |
| Animation count | 0 |
| Animation type list | None |
| UV mapping: Yes/No | Yes; 1 channel per mesh |
| LOD information (count, number of levels) | Base level only; 0 LOD Groups; no additional LODs |
| Types of materials and texture maps (e.g., PBR) | 7 URP/Lit materials plus 1 included marked-plastic URP shader; Base Color/Opacity and Metallic/Smoothness maps |
| Tested Unity / pipeline | 6000.6.1f1 / URP 17.6.0 |
| Tested editor platform | Windows |
| Materials | 8 |
| Unity imported vertices | 5858 total across the 9 FBX mesh components |
| Bounds in Unity X/Y/Z metres | 0.039576 / 0.155 / 0.017500 |
| Collisions | 1 capsule for the assembly + 1 thin flange box; approximate pickup collision |
| Dependencies | Universal RP; no external product assets or gameplay code |

# Keywords

syringe, medical, hospital, laboratory, water, needle, cap, healthcare, survival, inventory, PBR, prop, URP

# Installation and use

Import `Syringe_With_Water_Unity_URP.unitypackage` into Unity 6000.6.1f1 with URP 17.6.0. If starting from a non-URP project, install and configure URP first. The supplied pipeline and renderer are under `Settings`; assign the supplied pipeline in Graphics and Quality settings when a project has none. Drag `Prefabs/Syringe_With_Water.prefab` into a new scene. `Scenes/Overview.unity` is a neutral inspection setup.

The barrel shader reconstructs dark ink contrast from the alpha mask to keep the scale legible under texture minification. It supplies alpha transparency and a simple lit plastic highlight, without physical refraction. Other materials use URP/Lit. This appearance intentionally approximates Blender's ray-traced transmission; mobile, VR, HDRP and Built-in compatibility have not been tested.

`Barrel_MetallicSmoothness.png`: Metallic in R (zero for plastic), Smoothness = 1 − Roughness in A. Import with sRGB off; source base color is sRGB. Smoothness multiplier is 1. No normal maps. Source roughness remains in the exchange model textures.

Root position/rotation are zero and scale is one. Colliders approximate the assembled prop and flange; they do not provide a physically usable needle or fluid interaction. No Rigidbody is included. Clean-project package import, materials, mesh counts, UVs, dimensions, prefab transforms, colliders, dependencies and rendered output were checked. These checks do not imply Asset Store approval; the store's Asset Store Tools Validator was not run unless separately recorded.

## Files and dimensions

One complete syringe asset. Source and exchange versions contain nine named component meshes; the Unreal version combines them into one Static Mesh with eight material slots. Overall dimensions: **39.576 × 17.500 × 155.000 mm** in Blender X/Y/Z; Unity uses Y up and Unreal uses Z up. Pivot is at the centre of the bottom thumb-pad face. Model transforms are applied; engine asset roots have unit scale.

`source/Syringe_With_Water_Working.blend` preserves editable working topology. `export` contains the explicitly triangulated `.blend`, `.fbx`, `.obj` and `.mtl`. The final assembled asset contains **8,908 triangles**. No high-poly companion is supplied. Original Hunyuan uploads, internal reports and build scripts are excluded from buyer archives.

## Materials and textures

Eight materials: marked barrel, clear plastic, frosted cap, white plastic, black rubber, steel, water and needle hub. Two source PNG maps at **2048 × 2048**: `Barrel_BaseColorOpacity.png` (sRGB RGB color, alpha opacity) and `Barrel_Roughness.png` (linear roughness). Other surfaces use material constants. No normal map or AO map is supplied; no fictitious AO detail is added. Per-mesh UVs are unwrapped with no positive-area accidental overlaps. Separate meshes with uniform materials intentionally reuse UV space.

Blender uses Principled BSDF transmission and IOR (water 1.333; clear plastic 1.46). FBX carries alpha transparency approximations. OBJ/MTL contains PBR `Tf`/`Ni` data; support for those fields varies by importer. Keep `export` next to `textures` when unpacking a model archive. Re-link images to `../textures/` if an importer does not resolve relative paths automatically.

## Blender and exchange import

Verified in Blender **5.0.1**, rendered with Cycles. Open either `.blend`; import FBX or OBJ at scale 1 with matching Y-up exchange settings. The exchange files are triangulated in advance. The editable source contains a mixture of quads and justified triangles. Water has an outer closed boundary and a separate inward-facing closed air-cavity boundary; those two surfaces intentionally describe one liquid volume. Concealed mounting intersections at the flange, plunger, piston, hub and cap are intentional assembly contacts.

## Usage and limitations

The supplied fill and assembly are static. No fluid simulation, injection interaction, rig, animation, additional LODs or Nanite are included. This is a visual game prop; measurement markings are decorative. Transparent materials depend on lighting and the renderer. Studio backdrops, cameras and lights in the gallery are presentation elements, not extra products.


# AI description

OpenAI image generation was used for reference images. Hunyuan was used for a starting mesh. Codex generated and revised Blender Python scripts to reconstruct the final hollow geometry, water cavity, internal parts, UVs and procedural scale textures, and authored the included URP shader. The geometry was reduced from 50,000 to 8,908 triangles. Rendering, file reimports and engine checks were performed. The publisher must review and approve this AI-assisted listing draft before submission. See [Unity submission guidelines](https://assetstore.unity.com/publishing/submission-guidelines), section 1.6.
