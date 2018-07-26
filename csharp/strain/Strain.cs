using System;
using System.Collections.Generic;

public static class Strain {
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) {
        var enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext()) {
            if (predicate(enumerator.Current)) {
                yield return enumerator.Current;
            }
        }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) {
        var enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext()) {
            if (!predicate(enumerator.Current)) {
                yield return enumerator.Current;
            }
        }
    }
}