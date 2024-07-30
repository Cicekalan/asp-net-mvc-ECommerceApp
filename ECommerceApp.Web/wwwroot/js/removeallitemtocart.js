function removeAllItem(productId) {
    fetch(`/api/ShoppingCart/removeAll/${productId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ ProductId: productId, Quantity: 1 })
    })
    .then(response => {
        if (response.ok) {
            alert('Product removed from cart successfully!');
            location.reload(); 
        } else {
            alert('Failed to remove product from cart.');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('An error occurred while removing the product from cart.');
    });
}