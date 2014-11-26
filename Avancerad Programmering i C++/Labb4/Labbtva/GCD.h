template<typename Tint>
Tint GCD(Tint A, Tint B) {
	if (A<B)
		return GCD(B, A);
	while (B != 0) {
		Tint temp = A%B;
		A = B;
		B = temp;
	}
	if (A>0)	//beh�vs testen?????
		return A;
	else
		return 1;
}

template<typename Tint>
void Reduce(Tint& A, Tint& B) {
	Tint gcd = GCD(A, B);
	A /= gcd;
	B /= gcd;
}
