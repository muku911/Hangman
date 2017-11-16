using System;

namespace Util {
	public static class TextUtils {
		public static bool isUperAlpha(char c){
			return c >= 'A' && c <= 'Z'; 
		}

		public static bool isLowerAlpha(char c){
			return c >= 'a' && c <= 'z'; 
		}

		public static bool isUAlpha(char c){
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'); 
		}
	}
}

