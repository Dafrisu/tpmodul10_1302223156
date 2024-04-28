using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

public class Mahasiswa {
    public string nama { get; set; }
    public string NIM { get; set; }
}

namespace tpmodul10_1302223156.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : Controller
    {
        private static Mahasiswa[] mahasiswa = new Mahasiswa[]
        {
                new Mahasiswa{nama = "Dafa Raimi Suandi",NIM ="1302223156" },
                new Mahasiswa{nama = "Haikal Risnandar",NIM ="1302221050" },
                new Mahasiswa{nama = "Fersya Zufar",NIM ="1302223090" },
                new Mahasiswa{nama = "Mahesa Athaya Zain",NIM ="1302220105" },
                new Mahasiswa{nama = "Darryl Frizangelo Rambi",NIM ="1302223154" },
                new Mahasiswa{nama = "Raphael Permana Barus",NIM ="1302220140" },
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> GetMahasiswa()
        {
            return mahasiswa;
        }

        [HttpGet("{id}")]
        public Mahasiswa Get(int id) { 
            return mahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa input)
        {
            Mahasiswa newMahasiswa = new Mahasiswa
            {
                nama = input.nama,
                NIM = input.NIM
            };
            Mahasiswa[] newMahasiswas = new Mahasiswa[mahasiswa.Length + 1];

            for (int i = 0; i < mahasiswa.Length; i++)
            {
                newMahasiswas[i] = mahasiswa[i];
            }
            newMahasiswas[mahasiswa.Length] = newMahasiswa;
            mahasiswa = newMahasiswas;

            return CreatedAtAction(nameof(GetMahasiswa), newMahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswa.Length)
            {
                return NotFound("Indeks mahasiswa tidak valid");
            }

            // Hapus mahasiswa dari array berdasarkan indeks
            for (int i = id; i < mahasiswa.Length - 1; i++)
            {
                mahasiswa[i] = mahasiswa[i + 1];
            }
            Array.Resize(ref mahasiswa, mahasiswa.Length - 1);

            // Return 204 No Content response
            return NoContent();
        }
    }
}
