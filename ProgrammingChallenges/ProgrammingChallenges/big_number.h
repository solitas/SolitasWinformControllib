#pragma once
#include <stdio.h>
#include <stdlib.h>

#define MAXDIGITS 100

#define PLUS 1
#define MINUS -1

typedef struct {
	char digits[MAXDIGITS];
	int signbits;
	int last_digits;
} bignum;

void print_bignum(bignum* n)
{
	int i;
	if (n->signbits == MINUS)
	{
		printf("- ");
	}

	for (i = n->last_digits; i > 0; i--) 
	{
		printf("%c", '0' + n->digits[i]);
	}
	printf("\n");
}

void int_to_bignum(int s, bignum* n)
{
	int i;
	int t;

	n->signbits = (s >= 0) ? PLUS : MINUS;
	
	n->last_digits = -1;

	for (i = 0; i < MAXDIGITS; i++) {
		n->digits[i] = 0;
	}

	t = abs(s);
	
	while (t > 0) {
		n->last_digits++;
		n->digits[n->last_digits] = t % 10;
		t /= 10;
	}

	if (s == 0) n->last_digits = 0;
}

void initialize_bignum(bignum *n)
{
	int_to_bignum(0, n);
}

