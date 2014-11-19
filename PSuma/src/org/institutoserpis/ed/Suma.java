package org.institutoserpis.ed;

	import java.math.BigDecimal;
	import java.util.Scanner;

	public class Suma {
		
		public static void main(String[] args) {

			System.out.println("Programa para sumar dos números.");
		
	 		System.out.print("Introduce el primero: ");
			Scanner scanner = new Scanner(System.in);
			String primerDato = scanner.nextLine();

//			Con float tendremos problemas con "el redondeo"
//			float primerNumero = Float.parseFloat(primerDato);
//			
//			System.out.println("Primer número= " + primerDato);
//			
//	 		System.out.print("Introduce el segundo: ");
//	 		String segundoDato = scanner.nextLine();
//	 		
//	 		float segundoNumero = Float.parseFloat(segundoDato);
//	 		System.out.println("Segundo número= " + segundoNumero);
//
//	 		float suma = primerNumero + segundoNumero;
	 		
	 		BigDecimal primerNumero = new BigDecimal(primerDato);
			
			System.out.println("Primer número= " + primerDato);
			
	 		System.out.print("Introduce el segundo: ");
	 		String segundoDato = scanner.nextLine();
	 		
	 		BigDecimal segundoNumero = new BigDecimal(segundoDato);
	 		System.out.println("Segundo número= " + segundoNumero);

	 		BigDecimal suma = primerNumero.add(segundoNumero);
	 		System.out.println("La suma es: "+ suma);
		
	}
}
