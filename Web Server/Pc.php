<?php

function getRowNumber()
{
    $query = $this->db->query('SELECT * FROM products');
    echo ($query->num_rows());
}



function getCats()
{
    $query = $this->db->query('SELECT * FROM product_category')->result_array();
    $len = count($query);
    for ($i = 0; $i < $len; $i++)
        $cats .= $query[$i]['cat_id'] . "-";

    echo ($cats);
}

function getProducts($id, $cat)
{
    if ($id == 0) {
        $this->db->select('*');
        $result = $this->db->where("p_cat", $cat)->get('products')->result_array();
        $res="";
        for($i=0;$i<count($result);$i++)
        echo json_encode($result[$i])."-";
    } else {
        $last_row = $this->db->select('*')->where("p_id", $id)->get('products')->row();
        echo json_encode($last_row);
    }
}
function uyegiris($email,$pass)
{
    $last_row = $this->db->select('email');
    $last_row =$this->db->where('email',$email);
    $last_row =$this->db->where('sifre',$pass)->get('uyeler')->row();
    echo json_encode($last_row);
}
function Odeme($email, $adresBasligi, $adres, $sehir, $AdSoyad, $kartNo, $sonKullanma, $cvc,$urun_id){
    $data = array(
        'email' => $email,
        'adresBasligi' => $adresBasligi,
        'adres' => $adres,
        'sehir' => $sehir,
        'AdSoyad' => $AdSoyad,
        'sonKullanma' => $sonKullanma,
        'kartNo'=>$kartNo,
        'cvc' => $cvc,
        'urunler_id' => $urun_id
    );
    $this->db->insert("siparisler",$data);
}
function getOrderedProducts($email)
{
    $last_row = $this->db->select('urunler_id')->where("email", $email)->get('siparisler')->row();
    echo json_encode($last_row);
}

function getCategoryName($id)
{
    $last_row = $this->db->select('cat_name')->where("cat_id", $id)->get('product_category')->row();
    echo json_encode($last_row);
}
?>