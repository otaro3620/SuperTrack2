Shader "Huse360/DobleReloj"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "White" {}
        _param ("Param.", Float) = 0.5
    }
    SubShader
    {
      
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            uniform float _param;

            #define DIR float2(0,1)

            float4 frag (v2f_img i) : COLOR
            {
                //Agrega aquí el código de la transición DobleReloj:

                return 0;
            }


           
            ENDCG
        }// pass
    }// Subshader
}// Shader
