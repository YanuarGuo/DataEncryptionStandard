# Data Encryption Standard (DES) Encryption & Decryption Tool

This project is a simple Windows Forms application that allows users to encrypt and decrypt text using the Data Encryption Standard (DES) algorithm. It provides options for different padding schemes and output formats.

## Features
- **Encrypt and Decrypt Data** using DES algorithm
- **Custom Key and IV input** (8 bytes required)
- **Supports Padding Schemes:**
  - PKCS7
  - ZeroPadding
- **Selectable Output Format:**
  - Base64
  - HEX
- **GUI-based Windows Forms Application**

## Getting Started

### Prerequisites
- .NET 8.0
- Windows OS (for running Windows Forms applications)

### Installation
1. Clone this repository:
   ```sh
   git clone https://github.com/YanuarGuo/DataEncryptionStandard.git
   ```
2. Open the project in Visual Studio.
3. Build and run the project.

## Usage
### 1. Encryption Process
1. Enter the **Plaintext**.
2. Input the **Key** (must be 8 bytes).
3. Input the **IV** (must be 8 bytes).
4. Select **Padding** (PKCS7 or ZeroPadding).
5. Choose **Output Format** (Base64 or HEX).
6. Click **Encrypt** to generate the encrypted text.

### 2. Decryption Process
1. Enter the **Encrypted Text**.
2. Input the **Key** (same as used for encryption).
3. Input the **IV** (same as used for encryption).
4. Select **Padding** (same as used for encryption).
5. Choose **Input Format** (Base64 or HEX).
6. Click **Decrypt** to get the original plaintext.

## Code Explanation
### **Encrypt Function**
- Uses DES for encryption.
- Pads the key to 8 bytes using the selected padding method.
- Supports both **Base64** and **HEX** output.

### **Decrypt Function**
- Converts input from **Base64** or **HEX**.
- Uses DES for decryption.
- Returns the original plaintext.

### **Padding Function**
- Adds padding based on **PKCS7** or **ZeroPadding**.
- Ensures key length is exactly **8 bytes**.


## Author
Developed by **Yanuar Christy Ade Utama**.

