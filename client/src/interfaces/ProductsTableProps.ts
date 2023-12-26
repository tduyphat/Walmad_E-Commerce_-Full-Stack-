import Product from "./Product";

interface ProductsTableProps {
  filteredProducts: Product[];
  currentPage: number;
  limit: number;
  editMode: boolean;
  switchToEditMode: (product: Product) => void;
  handleDelete: (productId: number) => void;
}

export default ProductsTableProps;