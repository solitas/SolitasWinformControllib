#include "PrimaryArthmetic.h"
#include "big_number.h"

#include <stdlib.h>

int max(int n1, int n2)
{
	return n1 > n2 ? n1 : n2;
}

int get_number_of_carry(int num1, int num2) {
	int result = 0;
	int n;
	int c;
	int i;
	bignum* n1 = (bignum*)malloc(sizeof(bignum));
	bignum* n2 = (bignum*)malloc(sizeof(bignum));;

	int_to_bignum(num1, n1);
	int_to_bignum(num2, n2);

	n = max(num1, num2);
	for (i = 0; i < n; i++) {
		c = (n1->digits[i] + n2->digits[i]) / 10;

		if (c > 0) {
			result++;
		}
		
	}
}