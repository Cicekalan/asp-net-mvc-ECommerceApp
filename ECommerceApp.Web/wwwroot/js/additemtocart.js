function addToCart(productId) {
    fetch(`/api/ShoppingCart/AddItemToCart`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ ProductId: productId, Quantity: 1 })
    })
    .then(response => {
        if (response.ok) {
            alert('Product added to cart successfully!');
            location.reload(); 
        } else {
            alert('Failed to add product to cart.');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('An error occurred while adding the product to cart.');
    });
}