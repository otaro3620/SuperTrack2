Shader "cierre"
{
    Properties
    {
        //_MainTex ("Base (RGB)", 2D) = "White" {}
        //_param ("Param.", Float) = 0.5
    }
    SubShader
    {
      
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            //uniform sampler2D _MainTex;
            //uniform float _param;


            float4 frag (v2f_img i) : COLOR
            {
                //Agrega aqu� el c�digo de la transici�n Fade: 

                //float4 color =tex2D(_MainTex,i.uv);
				return float4(1,0,1,1);
                
            }

            ENDCG
        }// pass
    }// Subshader
}// Shader
