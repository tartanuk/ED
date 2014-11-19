package org.institutoserpis.ed;

public class Suma10 {

	public static void main(String[] args) {
		
		int suma = 0; 

//		int numero = 1;
//		while (numero <= 10){
//			suma = suma + numero;
//			numero++;
//		}
		
		for (int numero =1; numero <= 10; numero ++)
			suma = suma + numero;
		
		System.out.println("suma(1...10)= " + suma);

	}

}
