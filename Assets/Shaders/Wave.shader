// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Transparent/Cutout/Diffuse,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:True,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:0,x:34247,y:32655,varname:node_0,prsc:2|diff-330-OUT,spec-3-OUT,gloss-270-OUT,emission-330-OUT,alpha-8189-OUT;n:type:ShaderForge.SFN_Vector1,id:3,x:33777,y:32641,varname:node_3,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:270,x:33777,y:32701,varname:node_270,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Lerp,id:330,x:33701,y:32495,varname:node_330,prsc:2|A-7529-RGB,B-6159-RGB,T-5380-OUT;n:type:ShaderForge.SFN_Color,id:7529,x:33275,y:32143,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7529,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:6159,x:33275,y:32309,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_6159,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6620,x:33086,y:32408,varname:node_6620,prsc:2,ntxv:0,isnm:False|UVIN-8078-UVOUT,TEX-6059-TEX;n:type:ShaderForge.SFN_Sin,id:7703,x:32278,y:32345,varname:node_7703,prsc:2|IN-5437-TSL;n:type:ShaderForge.SFN_TexCoord,id:9162,x:31913,y:32631,varname:node_9162,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:4066,x:32650,y:32523,varname:node_4066,prsc:2|A-5018-OUT,B-9162-V;n:type:ShaderForge.SFN_Time,id:5437,x:32083,y:32345,varname:node_5437,prsc:2;n:type:ShaderForge.SFN_Slider,id:7271,x:32083,y:32499,ptovrint:False,ptlb:Stretch,ptin:_Stretch,varname:node_7271,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Panner,id:2774,x:32640,y:32650,varname:node_2774,prsc:2,spu:-0.8,spv:0|UVIN-6385-OUT;n:type:ShaderForge.SFN_Multiply,id:5018,x:32487,y:32429,varname:node_5018,prsc:2|A-7703-OUT,B-7271-OUT;n:type:ShaderForge.SFN_Multiply,id:2628,x:32838,y:32700,varname:node_2628,prsc:2|A-4066-OUT,B-2774-UVOUT;n:type:ShaderForge.SFN_Max,id:5380,x:33503,y:32592,varname:node_5380,prsc:2|A-8084-OUT,B-7868-R,C-7518-R;n:type:ShaderForge.SFN_Tex2dAsset,id:6059,x:32866,y:32512,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_6059,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7868,x:33086,y:32544,varname:node_7868,prsc:2,ntxv:0,isnm:False|UVIN-3779-UVOUT,TEX-6059-TEX;n:type:ShaderForge.SFN_Slider,id:737,x:32956,y:32820,ptovrint:False,ptlb:SecondaryFactor,ptin:_SecondaryFactor,varname:node_737,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5955049,max:1;n:type:ShaderForge.SFN_Multiply,id:8084,x:33305,y:32506,varname:node_8084,prsc:2|A-6620-R,B-737-OUT;n:type:ShaderForge.SFN_Panner,id:3779,x:32640,y:32791,varname:node_3779,prsc:2,spu:-0.45,spv:0|UVIN-8022-OUT;n:type:ShaderForge.SFN_Tex2d,id:7518,x:33086,y:32669,varname:node_7518,prsc:2,ntxv:0,isnm:False|UVIN-2774-UVOUT,TEX-6059-TEX;n:type:ShaderForge.SFN_Multiply,id:3397,x:32213,y:32806,varname:node_3397,prsc:2|A-9162-U,B-1193-OUT;n:type:ShaderForge.SFN_Vector1,id:1193,x:32060,y:32840,varname:node_1193,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Append,id:6385,x:32461,y:32794,varname:node_6385,prsc:2|A-3397-OUT,B-9162-V;n:type:ShaderForge.SFN_Multiply,id:1956,x:32213,y:32936,varname:node_1956,prsc:2|A-9162-U,B-9594-OUT;n:type:ShaderForge.SFN_Vector1,id:9594,x:32061,y:32983,varname:node_9594,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Append,id:8022,x:32448,y:32949,varname:node_8022,prsc:2|A-1956-OUT,B-9162-V;n:type:ShaderForge.SFN_Multiply,id:4439,x:32240,y:32597,varname:node_4439,prsc:2|A-9162-U,B-9801-OUT;n:type:ShaderForge.SFN_Vector1,id:9801,x:32060,y:32631,varname:node_9801,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Append,id:1062,x:32461,y:32585,varname:node_1062,prsc:2|A-4439-OUT,B-9162-V;n:type:ShaderForge.SFN_Panner,id:8078,x:32650,y:32381,varname:node_8078,prsc:2,spu:-0.3,spv:0|UVIN-1062-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8327,x:32864,y:33000,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8327,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:6682,x:33134,y:33313,ptovrint:False,ptlb:Threshold,ptin:_Threshold,varname:node_6682,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:8521,x:33259,y:33157,varname:node_8521,prsc:2,ntxv:0,isnm:False|TEX-8327-TEX;n:type:ShaderForge.SFN_TexCoord,id:6680,x:32765,y:33205,varname:node_6680,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4440,x:33586,y:33264,varname:node_4440,prsc:2|A-6682-OUT,B-3796-OUT;n:type:ShaderForge.SFN_Vector1,id:8685,x:33235,y:33517,varname:node_8685,prsc:2,v1:-1;n:type:ShaderForge.SFN_OneMinus,id:3796,x:33027,y:33483,varname:node_3796,prsc:2|IN-6680-U;n:type:ShaderForge.SFN_Clamp01,id:3689,x:33729,y:32893,varname:node_3689,prsc:2|IN-8577-OUT;n:type:ShaderForge.SFN_ScreenPos,id:4521,x:33136,y:32902,varname:node_4521,prsc:2,sctp:0;n:type:ShaderForge.SFN_Abs,id:7589,x:33359,y:32855,varname:node_7589,prsc:2|IN-4521-U;n:type:ShaderForge.SFN_Multiply,id:8577,x:33587,y:32855,varname:node_8577,prsc:2|A-6856-OUT,B-4797-OUT;n:type:ShaderForge.SFN_OneMinus,id:480,x:33920,y:32893,varname:node_480,prsc:2|IN-3689-OUT;n:type:ShaderForge.SFN_Min,id:8189,x:33941,y:33077,varname:node_8189,prsc:2|A-480-OUT,B-8521-R;n:type:ShaderForge.SFN_Slider,id:4797,x:33136,y:33059,ptovrint:False,ptlb:Factor,ptin:_Factor,varname:node_4797,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Max,id:2578,x:33575,y:33039,varname:node_2578,prsc:2|A-7589-OUT,B-6682-OUT;n:type:ShaderForge.SFN_Min,id:6856,x:33480,y:33134,varname:node_6856,prsc:2|A-7589-OUT,B-6682-OUT;proporder:7529-6159-7271-6059-737-8327-6682-4797;pass:END;sub:END;*/

Shader "Shader Forge/Wave" {
    Properties {
        [HDR]_Color ("Color", Color) = (0.5,0.5,0.5,1)
        [HDR]_Color2 ("Color2", Color) = (0.5,0.5,0.5,1)
        _Stretch ("Stretch", Range(0, 1)) = 0
        _Texture ("Texture", 2D) = "white" {}
        _SecondaryFactor ("SecondaryFactor", Range(0, 1)) = 0.5955049
        _Opacity ("Opacity", 2D) = "white" {}
        _Threshold ("Threshold", Range(0, 1)) = 0
        _Factor ("Factor", Range(0, 2)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            AlphaToMask On
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Color2;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _SecondaryFactor;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            uniform float _Threshold;
            uniform float _Factor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.4;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_3 = 0.2;
                float3 specularColor = float3(node_3,node_3,node_3);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float4 node_3134 = _Time;
                float2 node_8078 = (float2((i.uv0.r*0.3),i.uv0.g)+node_3134.g*float2(-0.3,0));
                float4 node_6620 = tex2D(_Texture,TRANSFORM_TEX(node_8078, _Texture));
                float2 node_3779 = (float2((i.uv0.r*0.25),i.uv0.g)+node_3134.g*float2(-0.45,0));
                float4 node_7868 = tex2D(_Texture,TRANSFORM_TEX(node_3779, _Texture));
                float2 node_2774 = (float2((i.uv0.r*0.2),i.uv0.g)+node_3134.g*float2(-0.8,0));
                float4 node_7518 = tex2D(_Texture,TRANSFORM_TEX(node_2774, _Texture));
                float3 node_330 = lerp(_Color.rgb,_Color2.rgb,max(max((node_6620.r*_SecondaryFactor),node_7868.r),node_7518.r));
                float3 diffuseColor = node_330;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_330;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_7589 = abs((sceneUVs * 2 - 1).r);
                float node_3689 = saturate((min(node_7589,_Threshold)*_Factor));
                float4 node_8521 = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                fixed4 finalRGBA = fixed4(finalColor,min((1.0 - node_3689),node_8521.r));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Color2;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _SecondaryFactor;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            uniform float _Threshold;
            uniform float _Factor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.4;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_3 = 0.2;
                float3 specularColor = float3(node_3,node_3,node_3);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_8151 = _Time;
                float2 node_8078 = (float2((i.uv0.r*0.3),i.uv0.g)+node_8151.g*float2(-0.3,0));
                float4 node_6620 = tex2D(_Texture,TRANSFORM_TEX(node_8078, _Texture));
                float2 node_3779 = (float2((i.uv0.r*0.25),i.uv0.g)+node_8151.g*float2(-0.45,0));
                float4 node_7868 = tex2D(_Texture,TRANSFORM_TEX(node_3779, _Texture));
                float2 node_2774 = (float2((i.uv0.r*0.2),i.uv0.g)+node_8151.g*float2(-0.8,0));
                float4 node_7518 = tex2D(_Texture,TRANSFORM_TEX(node_2774, _Texture));
                float3 node_330 = lerp(_Color.rgb,_Color2.rgb,max(max((node_6620.r*_SecondaryFactor),node_7868.r),node_7518.r));
                float3 diffuseColor = node_330;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_7589 = abs((sceneUVs * 2 - 1).r);
                float node_3689 = saturate((min(node_7589,_Threshold)*_Factor));
                float4 node_8521 = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                fixed4 finalRGBA = fixed4(finalColor * min((1.0 - node_3689),node_8521.r),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Color2;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _SecondaryFactor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_6884 = _Time;
                float2 node_8078 = (float2((i.uv0.r*0.3),i.uv0.g)+node_6884.g*float2(-0.3,0));
                float4 node_6620 = tex2D(_Texture,TRANSFORM_TEX(node_8078, _Texture));
                float2 node_3779 = (float2((i.uv0.r*0.25),i.uv0.g)+node_6884.g*float2(-0.45,0));
                float4 node_7868 = tex2D(_Texture,TRANSFORM_TEX(node_3779, _Texture));
                float2 node_2774 = (float2((i.uv0.r*0.2),i.uv0.g)+node_6884.g*float2(-0.8,0));
                float4 node_7518 = tex2D(_Texture,TRANSFORM_TEX(node_2774, _Texture));
                float3 node_330 = lerp(_Color.rgb,_Color2.rgb,max(max((node_6620.r*_SecondaryFactor),node_7868.r),node_7518.r));
                o.Emission = node_330;
                
                float3 diffColor = node_330;
                float node_3 = 0.2;
                float3 specColor = float3(node_3,node_3,node_3);
                float roughness = 1.0 - 0.4;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Transparent/Cutout/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
